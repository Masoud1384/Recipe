using Application.Contracts.RecipeContracts;
using Application.Contracts.RecipeIngredientContracts;
using Application.Contracts.UserContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Recipe.Pages
{
    [Authorize]
    public class CreateRecipeModel : PageModel
    {
        public List<CreateIngredientCommand> ingredients = new List<CreateIngredientCommand>();
        public CreateRecipeCommand recipe { get; set; }
        private readonly IUserApplication _userApplication;
        public CreateRecipeModel(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }
        public void OnGet(int userId)
        {

            
        }
        public async Task<IActionResult> OnPost(IFormFile? recipeImage)
        {

            return RedirectToPage("Index");
        }
    }
}
