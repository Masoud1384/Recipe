using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Repositories
{
    public interface IRecipeIngredientRepository
    {
        List<RecipeIngredient> SelectAllIngredient();
        RecipeIngredient FindIngredient(Expression<Func<RecipeIngredient, bool>> expression);
        bool DeleteIngredient(int IngredientId);
        bool AddIngredient(RecipeIngredient Ingredient);
        bool Update(RecipeIngredient Ingredient);
        void ActivateIngredient(int IngredientId);
    }
}
