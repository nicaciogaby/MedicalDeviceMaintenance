using MedicalDeviceMaintenance.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace MedicalDeviceMaintenance.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AdminController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        // GET: Admin
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var userViewModels = new List<UserViewModel>();
            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                userViewModels.Add(new UserViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Roles = roles.ToList()
                });
            }
            return View(userViewModels);
        }
        // GET: Admin/EditRole/id
        public async Task<IActionResult> EditRole(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            var roles = await _userManager.GetRolesAsync(user);
            var allRoles = _roleManager.Roles.Select(r => r.Name).ToList();
            var model = new EditRoleViewModel
            {
                UserId = user.Id,
                Email = user.Email,
                CurrentRole = roles.FirstOrDefault() ?? "None",
                AllRoles = allRoles
            };
            return View(model);
        }
        // POST: Admin/EditRole
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null) return NotFound();

            var currentRoles = await _userManager.GetRolesAsync(user);
            var removeResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);
            if (!removeResult.Succeeded)
            {
                TempData["Error"] = "Could not update this user's role. Please try again.";
                return RedirectToAction(nameof(Index));
            }

            var addResult = await _userManager.AddToRoleAsync(user, model.CurrentRole);
            if (!addResult.Succeeded)
            {
                TempData["Error"] = "Could not assign the new role. Please try again.";
                return RedirectToAction(nameof(Index));
            }

            TempData["Success"] = $"{user.Email}'s role was changed to {model.CurrentRole}.";
            return RedirectToAction(nameof(Index));
        }
        // POST: Admin/DeleteUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var email = user.Email;
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    TempData["Success"] = $"User \"{email}\" was deleted.";
                }
                else
                {
                    TempData["Error"] = "Something went wrong while deleting this user. Please try again.";
                }
            }
            else
            {
                TempData["Error"] = "User not found. They may have already been deleted.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
