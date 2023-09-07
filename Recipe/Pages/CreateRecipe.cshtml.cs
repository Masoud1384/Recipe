using Application.Contracts.RecipeContracts;
using Application.Contracts.RecipeIngredientContracts;
using Application.Contracts.UserContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Recipe.Pages
{
    [Authorize]
    public class CreateRecipeModel : PageModel
    {
        [BindProperty]
        public CreateRecipeCommand Recipe { get; set; }
        private readonly IUserApplication _userApplication;
        private readonly IRecipeApplication _recipeApplication;
        public CreateRecipeModel(IUserApplication userApplication, IRecipeApplication recipeApplication)
        {
            _userApplication = userApplication;
            _recipeApplication = recipeApplication;
        }
        public void OnGet(int userId)
        {
        }
        public async Task<IActionResult> OnPost(IFormFile? recipeImage, string ingredientsStr)
        {
            List<CreateIngredientCommand> ingredients = new List<CreateIngredientCommand>();
            var ings = ingredientsStr.Trim().Split(',').ToList();
            Recipe.AuthorId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value.ToString());
            //This way of saving image is strongly inefficient and unuseable and of course i don't recommend it
            //at all , but as a way to use something new i prefer to use it but ,PLEASE DON'T USE THIS WAY
            Recipe.Image = await EncodePic(recipeImage);

            var recipeId = _recipeApplication.AddRecipe(Recipe);
            foreach (var ingredient in ings)
            {
                ingredients.Add(new CreateIngredientCommand()
                {
                    IngredientName = ingredient,
                    RecipeId = recipeId
                });
            }
            _recipeApplication.AddIngredients(recipeId, ingredients);
            return RedirectToPage("Index");
        }
        private async Task<string> EncodePic(IFormFile image)
        {
            byte[] imageBytes;
            string imagestr;
            using (var memoryStream = new MemoryStream())
            {
                await image.CopyToAsync(memoryStream);
                imageBytes = memoryStream.ToArray();
                return Convert.ToBase64String(imageBytes);
            }
        }
    }    
}
