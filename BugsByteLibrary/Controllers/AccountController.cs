using BugsByteLibrary.Models;
using Core.Layer.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using MimeKit;

namespace BugsByteLibrary.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {

        private UserManager<AppUser> _userManager;

        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterViewModel v)
        {
            if (ModelState.IsValid)
            {
                Random random = new Random();
                int mailConfirmCode = random.Next(100000, 1000000);
                var appUser = new AppUser()
                {
                    Name = v.Name,
                    SurName = v.SurName,
                    Email = v.Email,
                    UserName = v.UserName,
                    ConfirmCode = mailConfirmCode
                };

                if (v.Password == v.ConfirmPassword)
                {
                    var result = await _userManager.CreateAsync(appUser, v.Password);

                    if (result.Succeeded)
                    {
                        MimeMessage mimeMessage = new MimeMessage();

                        MailboxAddress mailboxAddressFrom = new MailboxAddress("BugsByteLibrary'den", "ender.bkrr@gmail.com");
                        MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);
                        mimeMessage.From.Add(mailboxAddressFrom);
                        mimeMessage.To.Add(mailboxAddressTo);

                        var bodyBuilder = new BodyBuilder();
                        bodyBuilder.TextBody = "Kayıt işlmini gerçekleştirmek için onay kodunuz:" + mailConfirmCode;
                        mimeMessage.Body = bodyBuilder.ToMessageBody();

                        mimeMessage.Subject = "BugsBytes demeniz bir kod uzakda , mail doğrulama işlemi için kodunuz";

                        SmtpClient client = new SmtpClient();
                        client.Connect("smtp.gmail.com", 587, false);
                        client.Authenticate("ender.bkrr@gmail.com", "hlah hbdm uekk nuas");
                        client.Send(mimeMessage);
                        client.Disconnect(true);

                        

                        return RedirectToAction("Login", "Account");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                        return View(v);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Parola ile parola onayı eşleşmiyor.");
                }
            }

            return View(v);
        }




        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel model)
        {

            if (!ModelState.IsValid)//girilen model bilgileri hatalıysa , hata bilgilerini döndürmek için.
            {
                return View(model);
            }


            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent:true, lockoutOnFailure: false);


            if (result.Succeeded)
            {
                if (User.Identity.IsAuthenticated)
                {
                    var user = await _userManager.FindByNameAsync(User.Identity.Name);
                    if (user.EmailConfirmed == false)
                    {
                        return RedirectToAction("Index", "MailConfirm");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Default");
                    }
                }

            }


            if (result.IsNotAllowed)
            {
                ModelState.AddModelError(string.Empty, "Hesabınız henüz onaylanmamış veya geçersiz. Lütfen bilgi almak için yönetici ile iletişime geçin.");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı. Lütfen tekrar deneyin.");
            }

            return View(model);
        }



    }

}



