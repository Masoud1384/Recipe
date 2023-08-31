using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Repositories
{
    public interface IRecipeIngredientRepository : IRepository<int , RecipeIngredient>
    {
        //find by id , select all , add , isexist , savechange 
        RecipeIngredient FindIngredient(Expression<Func<RecipeIngredient, bool>> expression);
        List<RecipeIngredient> Ingredients(Expression<Func<Recipe, bool>> expression);
        void Update(RecipeIngredient recipeRating);
    }
}
