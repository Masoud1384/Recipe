using Domain.Entities;
using Domain.Repositories;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private Context _context;

        public RecipeRepository(Context context)
        {
            _context = context;
        }
        public void ActivateRecipe(int RecipeId)
        {
            throw new NotImplementedException();
        }

        public bool AddRecipe(Recipe Recipe)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRecipe(int RecipeId)
        {
            throw new NotImplementedException();
        }

        public Recipe FindRecipe(Expression<Func<Recipe, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public List<Recipe> SelectAllRecipes()
        {
            throw new NotImplementedException();
        }

        public bool Update(Recipe Recipe)
        {
            throw new NotImplementedException();
        }
    }
}
