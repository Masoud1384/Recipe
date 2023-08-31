using Domain.Entities;
using Domain.Repositories;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class RecipeIngredientRepository : Repository<int, RecipeIngredient>, IRecipeIngredientRepository
    {
        private Context _context;

        public RecipeIngredientRepository(Context context) : base(context)
        {
            _context = context;
        }

        public RecipeIngredient FindIngredient(Expression<Func<RecipeIngredient, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public List<RecipeIngredient> Ingredients(Expression<Func<Recipe, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Update(RecipeIngredient recipeRating)
        {
            throw new NotImplementedException();
        }
    }
}
