using Application.Contracts.RecipeContracts;
using Application.Contracts.UserContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Recipe.Pages
{
    [Authorize]
    public class CreateRecipeModel : PageModel
    {
        public CreateRecipeCommand recipe { get; set; }
        private readonly IUserApplication _userApplication;
        public CreateRecipeModel(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }
        public void OnGet(int userId)
        {
            
        }
    }
}
