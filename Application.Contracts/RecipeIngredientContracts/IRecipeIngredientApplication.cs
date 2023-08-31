using Domain.Entities;
using System.Linq.Expressions;

namespace Application.Contracts.RecipeIngredientContracts
{
    public interface IRecipeIngredientApplication
    {
        List<IngredientViewModel> SelectAllIngredient();
        IngredientViewModel FindIngredient(Expression<Func<RecipeIngredient, bool>> expression);
        void Delete(int IngredientId);
        void AddIngredient(CreateIngredientCommand createIngredientcommand);
        void Update(UpdateIngredientCommand updateIngredientCommand);
        void ActivateIngredient(int ingredientId);
    }
}
