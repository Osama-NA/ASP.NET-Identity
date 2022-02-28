using ASP.NET_Core_Identity.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP.NET_Core_Identity.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        [BindProperty]
        public Login Login { get; set; }

        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string? returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var identityResult = await _signInManager.PasswordSignInAsync(Login.Email, Login.Password, Login.RememberMe, false);
                if (identityResult.Succeeded)
                {
                    if(returnUrl != null && returnUrl != "/")
                    {
                        return RedirectToPage(returnUrl);
                    }
                    return RedirectToPage("Index");
                }
                ModelState.AddModelError(string.Empty, "Username or Password incorrect.");
            }
            return Page();
        }
    }
}
