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
            AppUser appUser = new AppUser()
            {
                Name = v.Name,
                SurName = v.SurName,
                Email = v.Email,
                UserName = v.UserName
            };
            if (v.Password == v.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appUser , v.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Default");
                }
                
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            return RedirectToAction("Index", "Default");




        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel l)
        {
            if (ModelState.IsValid)
            {

                var result = await _signInManager.PasswordSignInAsync(l.UserName, l.Password, false, false);

                return RedirectToAction("Index", "Default");


            }

            else
            {
                return RedirectToAction("Index", "Default");
            }

            
        }













    }

}



