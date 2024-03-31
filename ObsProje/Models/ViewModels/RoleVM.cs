using System.ComponentModel.DataAnnotations;

namespace ObsProje.Models.ViewModels
{
    public class RoleVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Rol adı boş geçilemez !")]
        public string RoleName { get; set; }
        [Required(ErrorMessage = "Rol açıklaması boş geçilemez !")]
        public string RoleDescription { get; set; }
    }
}
