using System.ComponentModel.DataAnnotations;

namespace BugsByteLibrary.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage ="kullanıcı adı boş geçilemez")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre Boş Geçilemez")]
        public string Password { get; set; }
    }
}
