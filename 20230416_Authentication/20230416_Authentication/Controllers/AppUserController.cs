using _20230416_Authentication.Models.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _20230416_Authentication.Controllers
{
    [Authorize]
    public class AppUserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AppUserController(UserManager<AppUser> userManager) => this._userManager = userManager;

        public IActionResult Index() => View(_userManager.Users);

        //public IActionResult Index(){
        //    return View(_userManager.Users);
        //}
    }
}
