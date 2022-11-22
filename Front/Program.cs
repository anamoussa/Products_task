using Core.Entities;
using Core.Interfaces;
using Infrastautcure;
using Infrastautcure.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);


//app.MapGet("/", () => "Hello World!");
//
builder.Services.AddTransient(typeof(DbContext), typeof(DataContext));
builder.Services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext
             <DataContext>(options =>
             {
                 options.UseLazyLoadingProxies()
                 .UseSqlServer(builder.Configuration.GetConnectionString("ProductDB"));
             });
builder.Services.AddIdentity<User, IdentityRole>
            ().AddEntityFrameworkStores<DataContext>();



builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;

});
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/User/SignIn";
    options.AccessDeniedPath = "/User/AccessDenied";
});
var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions()
{
    RequestPath = "/Content",
    FileProvider = new PhysicalFileProvider(
               Path.Combine(Directory.GetCurrentDirectory(), "Content")
               )
});

app.UseRouting();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.UseAuthentication();
app.UseAuthorization();

app.Run();
