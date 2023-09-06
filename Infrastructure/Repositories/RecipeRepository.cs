using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class RecipeRepository : Repository<int, Recipe>, IRecipeRepository
    {
        private Context _context;

        public RecipeRepository(Context context)
            :base(context)
        {
            _context = context;
        }

        public Recipe FindRecipe(Expression<Func<Recipe, bool>> expression)
        {
            return _context.recipes.FirstOrDefault(expression);
        }

        public List<Recipe> recipes(Expression<Func<Recipe, bool>> expression)
        {
            return _context.recipes.Include(i=>i._ingredients).Where(expression).ToList();
        }

        public void Update(Recipe recipe)
        {
            var Recipe = Get(recipe.Id);
            Recipe.Update(recipe);
            _context.SaveChanges();
        }
    }
}
