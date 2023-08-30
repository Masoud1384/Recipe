using Application.Contracts.RecipeContracts;
using Domain.Entities;
using System.Linq.Expressions;

namespace Application.Contracts.RecipeRatingContracts
{
    public interface IRecipeRating
    {
        List<Recipe> SelectAllRecipes();
        Recipe FindRecipe(Expression<Func<Recipe, bool>> expression);
        bool DeleteRecipe(int RecipeId);
        bool AddRecipe(CreateRecipeRatingCommand Recipe);
        bool Update(UpdateRecipeCommand Recipe);
        void ActivateRecipe(int RecipeId);

    }
}
