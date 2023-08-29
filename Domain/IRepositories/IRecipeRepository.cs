using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Repositories
{
    public interface IRecipeRepository
    {
        List<Recipe> SelectAllRecipes();
        Recipe FindRecipe(Expression<Func<Recipe, bool>> expression);
        bool DeleteRecipe(int RecipeId);
        bool AddRecipe(Recipe Recipe);
        bool Update(Recipe Recipe);
        void ActivateRecipe(int RecipeId);
    }
}
