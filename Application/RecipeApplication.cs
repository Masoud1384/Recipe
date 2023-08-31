using Application.Contracts.RecipeContracts;
using Domain.Entities;
using Domain.Repositories;
using System.Linq.Expressions;

namespace Application
{
    public class RecipeApplication : IRecipeApplication
    {
        private IRecipeRepository _reciperepository;

        public RecipeApplication(IRecipeRepository reciperepository)
        {
            _reciperepository = reciperepository;
        }

        public void ActivateRecipe(int RecipeId)
        {
            var recipe = _reciperepository.Get(RecipeId);
            if (recipe != null)
            {
                recipe.Restore();
                _reciperepository.SaveChanges();
            }
        }

        public void AddRecipe(CreateRecipeCommand Recipe)
        {
            var recipe = new Recipe(Recipe.Title, Recipe.Description, Recipe.Instructions, Recipe.AuthorId);
            _reciperepository.Create(recipe);
            _reciperepository.SaveChanges();
        }

        public void DeleteRecipe(int RecipeId)
        {
            var recipe = _reciperepository.Get(RecipeId);
            if (recipe != null)
            {
                recipe.Delete();
                _reciperepository.SaveChanges();
            }
        }

        public RecipeViewModel FindRecipe(Expression<Func<Recipe, bool>> expression)
        {
            var recipe = _reciperepository.FindRecipe(expression);
            return new RecipeViewModel
            {
                AuthorId = recipe.AuthorId,
                Description = recipe.Description,
                Instructions = recipe.Instructions,
                Id = recipe.Id,
                Title = recipe.Title,
            };
        }

        public List<RecipeViewModel> SelectAllRecipes()
        {
            return _reciperepository.Get().Select(x => new RecipeViewModel
            {
                Id = x.Id,
                Title = x.Title,
                AuthorId = x.AuthorId,
                Description = x.Description,
                Instructions = x.Instructions,
            }).OrderByDescending(x => x.Id).ToList();
        }

        public void Update(UpdateRecipeCommand Recipe)
        {
            var recipeUpdate = _reciperepository.FindRecipe(r => r.Id == Recipe.Id);
            if (recipeUpdate != null)
            {
                var updateobj = new Recipe(Recipe.Title, Recipe.Description, Recipe.Instructions, Recipe.AuthorId,recipeUpdate.Id);
               _reciperepository.Update(updateobj);
            }
            else
                throw new NullReferenceException();
        }
    }
}
