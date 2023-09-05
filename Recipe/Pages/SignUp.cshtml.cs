using Application.Contracts.UserContracts;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Recipe.Pages
{
    public class SignUpModel : PageModel
    {
        private readonly IUserApplication _userApplication;

        public SignUpModel(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        public CreateUserCommand user { get; set; }
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
        public async Task<IActionResult> OnPostAsync(CreateUserCommand user)
        {
            if (ModelState.IsValid)
            {
                var registrationSuccessful = _userApplication.AddUser(user);

                if (registrationSuccessful)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Role, SampleRoles.user),
                        new Claim(ClaimTypes.Email,user.Email)
                    };
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.UtcNow.AddDays(30)
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);
                    return RedirectToPage("Index");
                }
                ModelState.AddModelError(string.Empty, "Registration failed. Please try again.");
            }
            return Page();
        }
    }
}
