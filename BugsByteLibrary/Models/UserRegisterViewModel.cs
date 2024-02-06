using System.ComponentModel.DataAnnotations;

namespace BugsByteLibrary.Models
{
    public class UserRegisterViewModel

    {

        [Required(ErrorMessage = "Lütfen Kullanıcı Adınızı Giriniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Lütfen Adınızı Giriniz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen SoyAdınızı Giriniz")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Lütfen Mail Adresinizi Giriniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi Belirleyiniz")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Lütfen Şifrenizi Tekrar Giriniz")]
        [Compare("Password" , ErrorMessage = "Şifreler Uyumlu Değil")]
        public string ConfirmPassword { get; set; }
    }
}
