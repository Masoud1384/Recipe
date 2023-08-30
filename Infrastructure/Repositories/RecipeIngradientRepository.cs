using Domain.Entities;
using Domain.Repositories;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class RecipeIngradientRepository : IRecipeIngredientRepository
    {
        private Context _context;

        public RecipeIngradientRepository(Context context)
        {
            _context = context;
        }
        public void ActivateIngredient(int IngredientId)
        {
            throw new NotImplementedException();
        }

        public bool AddIngredient(RecipeIngredient Ingredient)
        {
            throw new NotImplementedException();
        }

        public bool DeleteIngredient(int IngredientId)
        {
            throw new NotImplementedException();
        }

        public RecipeIngredient FindIngredient(Expression<Func<RecipeIngredient, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public List<RecipeIngredient> SelectAllIngredient()
        {
            throw new NotImplementedException();
        }

        public bool Update(RecipeIngredient Ingredient)
        {
            throw new NotImplementedException();
        }
    }
}
