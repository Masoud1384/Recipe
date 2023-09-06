using Application.Contracts.RecipeContracts;
using Domain.Entities;
using Domain.Repositories;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using Application.Contracts.RecipeIngredientContracts;

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
                Image = recipe.Image,
            };
        }

        public List<RecipeViewModel> SelectAllRecipes()
        {
            var all = _reciperepository.Get().Select(x => new RecipeViewModel
            {
                Id = x.Id,
                Title = x.Title,
                AuthorId = x.AuthorId,
                Description = x.Description,
                Instructions = x.Instructions,
                Image = x.Image,
                Ingredients = (List<CreateIngredientCommand>)x._ingredients.ToList().Select(s => new CreateIngredientCommand
                {
                    IngredientName = s.IngredientName,
                    Quantity = s.Quantity,
                }),

            }).OrderByDescending(x => x.Id).ToList();
            return all;
        }

        public List<RecipeViewModel> SelectAllRecipes(Expression<Func<Recipe, bool>> expression)
        {
            return _reciperepository.recipes(expression).Select(x => new RecipeViewModel
            {
                Id = x.Id,
                Title = x.Title,
                AuthorId = x.AuthorId,
                Description = x.Description,
                Instructions = x.Instructions,
                Image = x.Image,                
                Ingredients = (List<CreateIngredientCommand>)x._ingredients.ToList().Select(s => new CreateIngredientCommand
                {
                    IngredientName = s.IngredientName,
                    Quantity = s.Quantity,
                }),
            }).ToList();
        }

        public void Update(UpdateRecipeCommand Recipe)
        {
            var recipeUpdate = _reciperepository.FindRecipe(r => r.Id == Recipe.Id);
            if (recipeUpdate != null)
            {
                var updateobj = new Recipe(Recipe.Title, Recipe.Description, Recipe.Instructions, Recipe.AuthorId, recipeUpdate.Id);
                _reciperepository.Update(updateobj);
            }
            else
                throw new NullReferenceException();
        }
    }
}
