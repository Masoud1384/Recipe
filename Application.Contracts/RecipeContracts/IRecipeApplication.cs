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
        void AddRecipe(CreateRecipeCommand Recipe);
        void Update(UpdateRecipeCommand Recipe);
        void ActivateRecipe(int RecipeId);
    }
}
