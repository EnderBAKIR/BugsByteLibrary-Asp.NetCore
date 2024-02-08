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
        public async Task<IActionResult> Login(UserLoginViewModel l)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(l.UserName, l.Password, false, false);

                if (result.Succeeded)
                {
                    
                    return RedirectToAction("Index", "Default");
                }
                
                if (result.IsNotAllowed) 
                {
                    
                ModelState.AddModelError("", "Kullanıcı Adı Veya Şifreniz Yanlış");
                    return View(l);
                
                }
                    
                    

                    
                    
                
            }

            // ModelState.IsValid false ise, yani model doğrulama hatası varsa, aynı view sayfasını tekrar göster.
            ModelState.AddModelError("", "Kullanıcı Adı Veya Şifreniz Yanlış");
            return View(l);
        }













    }

}



