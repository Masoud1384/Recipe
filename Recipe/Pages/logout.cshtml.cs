using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Recipe.Pages
{
    public class logoutModel : PageModel
    {
        public async void OnGet()
        {
            if(User.Identity.IsAuthenticated)
            {
               await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                Response.WriteAsync("loged Outed");
            }
        }
    }
}
