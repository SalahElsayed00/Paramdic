using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Paramdic.ViewModels;
using System.Threading.Tasks;

namespace Paramdic.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                //mapping between IdentityUser class And RegisterVM class
                IdentityUser user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };
                //Created new user in IdentityUser table 
                IdentityResult result = await userManager.CreateAsync(user, model.Password);
                //check on the user data 
                if (result.Succeeded)
                {
                    //if (userManager.Options.SignIn.RequireConfirmedEmail)
                    //{
                    //    // generate token
                    //    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);

                    //    //create link
                    //    var confirmLink = Url.Action("Confirm","Account",new { UserId = user.Id, token=token });
                    //}
                    await signInManager.SignInAsync(user, isPersistent: true);
                    return RedirectToAction("index", "Home");
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        //[Route("Account/salahlogin")]
        public IActionResult Login(string returnUrl)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ViewData["returnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM model,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await userManager.FindByEmailAsync(model.Email);
                if (existingUser == null)
                {
                    TempData["Message"] = "Invalid Email Or Password";
                    return View(model);
                }
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: model.RememberMe, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("index", "Home");
                }
                else if (result.IsNotAllowed)
                {
                    TempData["error"] = "Required Confirm Email ";
                }
                
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Logout(IdentityUser user)
        {
            if (user != null)
            {
                await signInManager.SignOutAsync();
            }

            return RedirectToAction("index", "Home");
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await userManager.GetUserAsync(User);

                if (user == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                IdentityResult result = await userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    await signInManager.RefreshSignInAsync(user);
                    return RedirectToAction("index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }
        
       }
    
}
