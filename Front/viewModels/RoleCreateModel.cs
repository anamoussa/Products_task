using System.ComponentModel.DataAnnotations;

namespace Front.viewModels
{
    public class RoleCreateModel
    {
        [Required]
        public string Name { get; set; }
    }
}
