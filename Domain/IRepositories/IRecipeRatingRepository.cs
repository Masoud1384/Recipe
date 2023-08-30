using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Repositories
{
    public interface IRecipeRatingRepository
    {
        List<RecipeRating> SelectAllRatings();
        Recipe FindRating(Expression<Func<RecipeRating, bool>> expression);
        bool DeleteRecipe(int RateId);
        bool AddRecipe(RecipeRating RecipeRating);
        bool Update(RecipeRating RecipeRating);
        void ActivateRecipe(int RateId);
    }
}
