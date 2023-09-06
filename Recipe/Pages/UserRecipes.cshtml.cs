using Application.Contracts.RecipeContracts;
using Application.Contracts.UserContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Recipe.Pages
{
    [Authorize]
    public class UserRecipesModel : PageModel
    {
        public List<RecipeViewModel> recipes { get; set; }
        private readonly IRecipeApplication _recipeApplication;
        private readonly IUserApplication _userApplication;
        public UserRecipesModel(IUserApplication userApplication, IRecipeApplication recipeApplication)
        {
            _userApplication = userApplication;
            _recipeApplication = recipeApplication;
        }
        public void OnGet(int userId)
        {
            recipes = _recipeApplication.SelectAllRecipes(u => u.AuthorId == userId);
        }
    }
}
