using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ObsProje.Models.ViewModels
{
    public class UserVM
    {
        
        public int ID { get; set; }
        [Required(ErrorMessage="Kullanıcı adı boş geçilemez")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre boş geçilemez")]
        public string Password { get; set; }
        [Required(ErrorMessage = "İsim alanı boş geçilemez")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyisim boş geçilemez")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Telefon numarası boş geçilemez")]
        public string TelNo { get; set; }
        [Required(ErrorMessage = "Adres boş geçilemez")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Kimlik numarası boş geçilemez")]
        public string TCKN { get; set; }
        [Required(ErrorMessage = "E-Mail boş geçilemez !")]
        public string Email { get; set; }
        public IEnumerable<SelectListItem>? Roles { get; set; }
        public int RoleID { get; set; }
        [Required(ErrorMessage = "Rol alanı boş geçilemez !")]
        public string? UserRole { get; set; }
    }
}
