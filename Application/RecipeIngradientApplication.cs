using Application.Contracts.RecipeIngredientContracts;
using Domain.Entities;
using Domain.Repositories;
using System.Linq.Expressions;

namespace Application
{
    public class RecipeIngradientApplication : IRecipeIngredientApplication
    {
        private IRecipeIngredientRepository _ingradientRepository;

        public RecipeIngradientApplication(IRecipeIngredientRepository ingradientRepository)
        {
            _ingradientRepository = ingradientRepository; 
        }
        public void ActivateIngredient(int ingredientId)
        {
            throw new NotImplementedException();
        }

        public bool Add(CreateIngredientCommand Recipe)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int RecipeId)
        {
            throw new NotImplementedException();
        }

        public IngredientViewModel Find(Expression<Func<Recipe, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public List<IngredientViewModel> SelectAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(UpdateIngredientCommand Recipe)
        {
            throw new NotImplementedException();
        }
    }
}
