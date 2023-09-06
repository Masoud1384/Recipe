using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Application.Contracts.RecipeContracts;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Recipe.Pages
{
    [Authorize]
    public class EditRecipeModel : PageModel
    {
        private readonly IRecipeApplication _recipeApplication;

        public EditRecipeModel(IRecipeApplication recipeApplication)
        {
            _recipeApplication = recipeApplication;
        }

        public UpdateRecipeCommand recipe { get; set; }

        public void OnGet(int recipeId)
        {
            var Recipe = _recipeApplication.FindRecipe(r=>r.Id==recipeId);
            #region Initializing recipe
            recipe.Title = Recipe.Title;    
            recipe.Description = Recipe.Description;    
            recipe.AuthorId = Recipe.AuthorId;    
            recipe.Instructions = Recipe.Instructions;    
            recipe.Ingredients = Recipe.Ingredients;    
            recipe.Id = Recipe.Id;
            #endregion
        }
    }
}
