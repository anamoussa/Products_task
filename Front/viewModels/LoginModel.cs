using System.ComponentModel.DataAnnotations;

namespace Front.viewModels
{
    public class LoginModel
    {

        [Required, MinLength(3)]
        public string Email { get; set; }
        [Required, MinLength(3), DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
