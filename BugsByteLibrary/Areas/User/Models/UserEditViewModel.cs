using System.ComponentModel.DataAnnotations;

namespace BugsByteLibrary.Areas.User.Models
{
    public class UserEditViewModel
    {
        [Required(ErrorMessage ="UserName Değiştirilemez")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "İsim Boş Bırakılamaz")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyisim Boş Bırakılamaz")]
        public string Surname { get; set; }
        
        public string Password { get; set; }
        
        [Compare("Password", ErrorMessage = "Şifreler Uyumlu Değil")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Email Değiştirilemez")]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

       

        public IFormFile Image { get; set; }
    }
}
