using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Repositories
{
    public interface IRecipeRatingRepository : IRepository<int , RecipeRating>
    {
        //find by id , select all , add , isexist , savechange 
        RecipeRating FindRating(Expression<Func<RecipeRating, bool>> expression);
        List<RecipeRating> Ratings(Expression<Func<Recipe, bool>> expression);
        void Update(RecipeRating recipeRating);
    }
}
