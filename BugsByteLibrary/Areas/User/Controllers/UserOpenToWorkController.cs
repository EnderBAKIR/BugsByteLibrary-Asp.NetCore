﻿using BugsByteLibrary.Controllers;
using Core.Layer.IService;
using Core.Layer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BugsByteLibrary.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class UserOpenToWorkController : Controller
    {

        private readonly IOpenToWorkService _openToWorkService;

        private readonly UserManager<AppUser> _userManager;

        public UserOpenToWorkController(IOpenToWorkService openToWorkService, UserManager<AppUser> userManager)
        {
            _openToWorkService = openToWorkService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {

            var userMail = await _userManager.FindByNameAsync(User.Identity.Name);

            // Eğer kullanıcı e-posta doğrulaması yapmamışsa, kullanıcıyı mail doğrulama işlemine atıcak
            if (!userMail.EmailConfirmed)
            {
                return RedirectToAction(nameof(MailConfirmController.Index), "MailConfirm");
            }


            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var openToWorks = await _openToWorkService.GetOpenWorksByUserIdAsync(user.Id);


            return View(openToWorks);

        }

        [HttpGet]
        public async Task<IActionResult> UpdateOpenToWork(string id)
        {

            var userMail = await _userManager.FindByNameAsync(User.Identity.Name);

            // Eğer kullanıcı e-posta doğrulaması yapmamışsa, kullanıcıyı mail doğrulama işlemine atıcak
            if (!userMail.EmailConfirmed)
            {
                return RedirectToAction(nameof(MailConfirmController.Index), "MailConfirm");
            }


            var openToWork = await _openToWorkService.GetOpenToWorkByIdAsnc(id);

            return View(openToWork);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOpenToWork(OpenToWork openToWork)
        {

            var userMail = await _userManager.FindByNameAsync(User.Identity.Name);

            // Eğer kullanıcı e-posta doğrulaması yapmamışsa, kullanıcıyı mail doğrulama işlemine atıcak
            if (!userMail.EmailConfirmed)
            {
                return RedirectToAction(nameof(MailConfirmController.Index), "MailConfirm");
            }


            openToWork.Status = true;
            openToWork.UpdateTime= DateTime.Now;

            await _openToWorkService.UpdateOpenToWorkAsync(openToWork);


            return RedirectToAction(nameof(Index));
        }
    }
}
