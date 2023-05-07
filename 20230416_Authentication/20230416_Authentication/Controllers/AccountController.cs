using _20230416_Authentication.Models.DTOs;
using _20230416_Authentication.Models.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _20230416_Authentication.Controllers
{
    [Authorize] // Yetki sahibi olmadan hiç bir kullanıcı görüntüleyemez.
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IPasswordHasher<AppUser> _passwordHasher;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IPasswordHasher<AppUser> passwordHasher)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._passwordHasher = passwordHasher;
        }

        #region Registration

        [AllowAnonymous] // Yetki sahibi olmadan tüm kullanıcılar görüntüleyebilir.
        public IActionResult Register() => View();

        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = model.UserName,
                    Email = model.Email
                };
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

        #endregion

        #region Login

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            var model = new LoginDTO() { ReturnURL = returnUrl };
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken, AllowAnonymous]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = await _userManager.FindByNameAsync(loginDTO.UserName);
                if (appUser != null)
                {
                    var signInResult = await _signInManager.PasswordSignInAsync(appUser, loginDTO.Password, false, false);
                    if (signInResult.Succeeded)
                        return Redirect(loginDTO.ReturnURL ?? "/");

                    ModelState.AddModelError("", "Giriş işlemi esnasında bir hata meydana geldi.");
                }
            }
            return View(loginDTO);
        }

        #endregion

        #region LogOut

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/");
        }

        #endregion

        #region Edit Profile

        public async Task<IActionResult> Edit()
        {
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var userUpdateDto = new UserUpdateDTO(appUser);
            return View(userUpdateDto);
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(UserUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
                appUser.UserName = model.UserName;
                appUser.Email = model.Email;
                if (
                    (!string.IsNullOrEmpty(model.Password) &&
                    !string.IsNullOrEmpty(model.PasswordConfirm)) &&
                    (model.Password == model.PasswordConfirm)
                   )
                {
                    appUser.PasswordHash = _passwordHasher.HashPassword(appUser, model.Password);
                }

                var identityResult = await _userManager.UpdateAsync(appUser);
                if (identityResult.Succeeded)
                {
                    await _signInManager.RefreshSignInAsync(appUser);
                    TempData["Success"] = "<div class='alert alert-success'>Kullanıcı güncelleme işlemi başarı ile tamamlandı.</div>";
                    return Redirect("/");
                }

                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                TempData["Error"] = "<div class='alert alert-danger'>Kullanıcı güncelleme işlemi esnasında bir hata meydana geldi.</div>";
            }
            return View(model);
        }

        #endregion
    }
}
