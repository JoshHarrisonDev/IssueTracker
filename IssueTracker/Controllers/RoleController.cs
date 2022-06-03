using IssueTracker.Models;
using IssueTracker.Services.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace IssueTracker.Controllers
{
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<IdentityUser> _userManager;
        private IPersonService _personService;
        private IdentityDbContext _identityDbContext;
        public RoleController(RoleManager<IdentityRole> roleManager, IPersonService personService, UserManager<IdentityUser> userManager, IdentityDbContext identityDbContext)
        {
            _roleManager = roleManager;
            _personService = personService;
            _userManager = userManager;
            _identityDbContext = identityDbContext;
        }
        // GET: RoleController
        public ActionResult Index()
        {

            return View(_roleManager.Roles);
        }

        // GET: RoleController/Details/5
        public async Task<IActionResult> ViewRole(string id)
        {

            var userRoles = _identityDbContext.UserRoles.ToList();
            foreach (var userRole in userRoles)
            {
                if (userRole.RoleId == id)
                {
                    var role = await _roleManager.FindByIdAsync(userRole.RoleId);

                    var users = await _userManager.GetUsersInRoleAsync(role.Name);

                    IdentityUserList identityUserList = new IdentityUserList()
                    {
                        Users = users,
                        RoleName = role.Name
                    };
                    return View(identityUserList);
                }
            }
            return RedirectToAction("Index");
        }

        // GET: RoleController/Create

        public ActionResult AssignUserToRole()
        {
            RoleAssign roleAssign = new RoleAssign();
            roleAssign.Roles = _roleManager.Roles.ToList();
            roleAssign.RolelessPeople = _personService.GetRolelessPeople();

            return View(roleAssign);
        }
        public ActionResult ReAssignUserToRole()
        {
            RoleAssign roleAssign = new RoleAssign();
            roleAssign.Roles = _roleManager.Roles.ToList();
            roleAssign.RolelessPeople = _personService.GetAll();

            return View(roleAssign);
        }
        [HttpPost]
        public ActionResult RemoveRole(int id)
        {
            _personService.RemoveRole(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AssignUserToRole(RoleAssign roleAssign)
        {
            var person = _personService.Get(roleAssign.UserID);
            _personService.AssignRole(roleAssign.RoleName, roleAssign.UserID);
            IdentityUser identityUser = await _userManager.FindByEmailAsync(person.Email);
            await _userManager.AddToRoleAsync(identityUser, roleAssign.RoleName);
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IdentityRole identityRole)
        {
            try
            {
                await _roleManager.CreateAsync(identityRole);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RoleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RoleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RoleController/Delete/5


        // POST: RoleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(id);
                var people = _personService.GetAll();
                foreach (var person in people)
                {
                    if (person.Role == role.Name)
                    {
                        _personService.RemoveRole(person.ID);
                    }
                }
                await _roleManager.DeleteAsync(role);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
