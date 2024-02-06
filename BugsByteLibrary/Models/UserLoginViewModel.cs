using System.ComponentModel.DataAnnotations;

namespace BugsByteLibrary.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage ="İsim veya kullanıcı adınız yanlış")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "İsim veya kullanıcı adınız yanlış")]
        public string Password { get; set; }
    }
}
