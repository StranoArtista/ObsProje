using System.ComponentModel.DataAnnotations;

namespace ObsProje.Models.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage="Kullanıcı adı boş geçilemez.")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Şifre boş geçilemez")]
        public string Password { get; set; }
        
    }
}
