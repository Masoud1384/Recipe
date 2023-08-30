using Domain.Entities;
using System.Linq.Expressions;

namespace Application.Contracts.RecipeIngredientContracts
{
    public interface IRecipeIngredientApplication
    {
        List<IngredientViewModel> SelectAll();
        IngredientViewModel Find(Expression<Func<Recipe, bool>> expression);
        bool Delete(int RecipeId);
        bool Add(CreateIngredientCommand Recipe);
        bool Update(UpdateIngredientCommand Recipe);
        void ActivateIngredient(int ingredientId);
    }
}
