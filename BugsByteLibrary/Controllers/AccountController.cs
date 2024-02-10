using BugsByteLibrary.Models;
using Core.Layer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

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
                AppUser appUser = new AppUser()
                {
                    Name = v.Name,
                    SurName = v.SurName,
                    Email = v.Email,
                    UserName = v.UserName
                };

                if (v.Password == v.ConfirmPassword)
                {
                    var result = await _userManager.CreateAsync(appUser, v.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Default");
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
        public  IActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel model)
        {
            // ViewModel'in ModelState'i geçerli değilse, hata mesajlarıyla birlikte geri dön
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Kullanıcı adı ve şifreyi kullanarak giriş işlemini gerçekleştir
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent: true, lockoutOnFailure: false);

            // Giriş başarılı ise ana sayfaya yönlendir
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Default");
            }

            
            if(result.IsNotAllowed)
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



