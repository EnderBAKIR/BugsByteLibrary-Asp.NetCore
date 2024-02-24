using BugsByteLibrary.Areas.Admin.Models;
using Core.Layer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BugsByteLibrary.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            if (!User.IsInRole("Admin"))
            {
                return NotFound();
            }

            var value = await _roleManager.Roles.ToListAsync();
            return View(value);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            if (!User.IsInRole("Admin"))
            {
                return NotFound();
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddRole(CreateRoleViewModel createRoleViewModel)
        {
            if (!User.IsInRole("Admin"))
            {
                return NotFound();
            }
            AppRole role = new()
            {
                Name = createRoleViewModel.RoleName
            };

            var model = await _roleManager.CreateAsync(role);

            if (model.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }


        }
        public async Task<IActionResult>DeleteRole(int id)
        {
            if (!User.IsInRole("Admin"))
            {
                return NotFound();
            }
            var role =  await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
            await _roleManager.DeleteAsync(role);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> EditRole(int id )
        {
            if (!User.IsInRole("Admin"))
            {
                return NotFound();
            }
            var role = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
            EditRoleViewModel editRoleViewModel = new()
            {
                RoleId = role.Id,
                RoleName = role.Name
            };
            return View(editRoleViewModel);
        }



        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel editRoleViewModel)
        {
            if (!User.IsInRole("Admin"))
            {
                return NotFound();
            }
            var value =  _roleManager.Roles.FirstOrDefault(x=>x.Id == editRoleViewModel.RoleId);
            value.Name = editRoleViewModel.RoleName;
            value.Id = value.Id;
            
           
            await _roleManager.UpdateAsync(value);
            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> UserList()
        {
            if (!User.IsInRole("Admin"))
            {
                return NotFound();
            }
            var value = await _userManager.Users.ToListAsync();
            return View(value);
        }

        public async Task<IActionResult> GiveRole(int id)
        {
            if (!User.IsInRole("Admin"))
            {
                return NotFound();
            }
            var userGetById = await _userManager.Users.FirstOrDefaultAsync(x=> x.Id == id);
            TempData["UserId"] = userGetById.Id;
            var roles = await _roleManager.Roles.ToListAsync();
            var UserRoles = await _userManager.GetRolesAsync(userGetById);
            List<GiveRoleViewModel> giveRoleViewModels = new();
            foreach (var item in roles)
            {
                GiveRoleViewModel model = new();
                model.RoleId = item.Id;
                model.RoleName = item.Name;
                model.RoleExist = UserRoles.Contains(item.Name);
                giveRoleViewModels.Add(model);
            }

            return View(giveRoleViewModels);
        }
        [HttpPost]
        public async Task<IActionResult> GiveRole(List<GiveRoleViewModel> models)
        {
            if (!User.IsInRole("Admin"))
            {
                return NotFound();
            }

            var userId = (int)TempData["UserId"];
            var user = await _userManager.Users.FirstOrDefaultAsync(x=> x.Id ==userId );

            foreach (var item in models)
            {
                if (item.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }
            return RedirectToAction(nameof(UserList));
        }

    }
}
