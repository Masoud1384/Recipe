using Domain.Entities;
using System.Linq.Expressions;

namespace Application.Contracts.RecipeRatingContracts
{
    public interface IRecipeRatingApplication
    {
        List<RecipeRatingViewModel> SelectAllRecipes();
        RecipeRatingViewModel FindRecipe(Expression<Func<RecipeRating, bool>> expression);
        void Delete(int RecipeId);
        void AddRating(CreateRecipeRatingCommand rating);
        void Update(UpdateRatingRecipeCommand rating);
        void ActivateRating(int RecipeId);

    }
}
