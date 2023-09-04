using Application.Contracts.UserContracts;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Recipe.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IUserApplication _userApplication;

        public LoginModel(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        public LoginUserCommand user { get; set; }
        public async Task<IActionResult> OnGet()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Page();
            }
            else
            {
                return RedirectToPage("/Info");
            }
        }
        public async Task<IActionResult> Login(LoginUserCommand user)
        {
            // Authenticate the user (validate credentials)
            if (ModelState.IsValid)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username),
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                // Determine whether to create a persistent cookie based on the "rememberMe" parameter
                AuthenticationProperties authenticationProperties = null;
                if (user.RememberMe)
                {
                    authenticationProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30) // Adjust the expiration time as needed
                    };
                }

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties);

                return RedirectToAction("Index", "Home");
            }

            // Authentication failed, return error
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }

    }
}
