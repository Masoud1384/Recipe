using Application.Contracts.RecipeContracts;
using Domain.Entities;
using System.Linq.Expressions;

namespace Application
{
    public class RecipeApplication : IRecipeApplication
    {
        public void ActivateRecipe(int RecipeId)
        {
            throw new NotImplementedException();
        }

        public bool AddRecipe(CreateRecipeCommand Recipe)
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

        public bool Update(UpdateRecipeCommand Recipe)
        {
            throw new NotImplementedException();
        }
    }
}
