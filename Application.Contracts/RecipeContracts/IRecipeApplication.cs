using Application.Contracts.RecipeIngredientContracts;
using Domain.Entities;
using System.Linq.Expressions;

namespace Application.Contracts.RecipeContracts
{
    public interface IRecipeApplication
    {
        List<RecipeViewModel> SelectAllRecipes();
        List<RecipeViewModel> SelectAllRecipes(Expression<Func<Recipe, bool>> expression);
        RecipeViewModel FindRecipe(Expression<Func<Recipe, bool>> expression);
        void DeleteRecipe(int RecipeId);
        int AddRecipe(CreateRecipeCommand Recipe);
        void Update(UpdateRecipeCommand Recipe);
        void AddIngredients(int recipeId, List<CreateIngredientCommand> ingredientsCommand);
        void ActivateRecipe(int RecipeId);
    }
}
