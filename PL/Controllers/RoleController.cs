using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace PL.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index(string search)
        {
            var roles = string.IsNullOrEmpty(search)
                ? _roleManager.Roles.ToList()
                : _roleManager.Roles.Where(r => r.Name.Contains(search)).ToList();

            return View(roles);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
                return View();

            var roleExists = _roleManager.RoleExistsAsync(roleName).Result;
            if (roleExists)
            {
                ModelState.AddModelError("", "Role already exists.");
                return View();
            }

            var result = _roleManager.CreateAsync(new IdentityRole(roleName)).Result;
            if (result.Succeeded)
                return RedirectToAction("Index");

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View();
        }

        public IActionResult Edit(string id)
        {
            var role = _roleManager.FindByIdAsync(id).Result;
            if (role == null)
                return NotFound();

            return View(role);
        }

        [HttpPost]
        public IActionResult Edit(string id, string roleName)
        {
            var role = _roleManager.FindByIdAsync(id).Result;
            if (role == null)
                return NotFound();

            role.Name = roleName;
            var result = _roleManager.UpdateAsync(role).Result;

            if (result.Succeeded)
                return RedirectToAction("Index");

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(role);
        }

        public IActionResult Details(string id)
        {
            var role = _roleManager.FindByIdAsync(id).Result;
            if (role == null)
                return NotFound();

            return View(role);
        }

        public IActionResult Delete(string id)
        {
            var role = _roleManager.FindByIdAsync(id).Result;
            if (role == null)
                return NotFound();

            return View(role);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string id)
        {
            var role = _roleManager.FindByIdAsync(id).Result;
            if (role == null)
                return NotFound();

            var result = _roleManager.DeleteAsync(role).Result;
            if (result.Succeeded)
                return RedirectToAction("Index");

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(role);
        }
    }
}
