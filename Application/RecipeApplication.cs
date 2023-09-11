using Application.Contracts.RecipeContracts;
using Domain.Entities;
using Domain.Repositories;
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

        public void AddIngredients(int recipeId, List<CreateIngredientCommand> ingredientsCommand)
        {
            var recipe = _reciperepository.FindRecipe(r => r.Id == recipeId);
            if (recipe != null)
            {
                var recipeIngredients = ingredientsCommand.Select(i => new RecipeIngredient(i.IngredientName, i.RecipeId)).ToList();
                _reciperepository.AddIngredient(recipeId, recipeIngredients);
            }
        }

        public int AddRecipe(CreateRecipeCommand Recipe)
        {
            var recipe = new Recipe(Recipe.Title, Recipe.Description, Recipe.Instructions, Recipe.Image, Recipe.AuthorId);
            var id = _reciperepository.AddRecipe(recipe);
            _reciperepository.SaveChanges();
            return id;
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
            if (recipe != null)
            {
                return new RecipeViewModel
                {
                    AuthorId = recipe.AuthorId,
                    Description = recipe.Description,
                    Instructions = recipe.Instructions,
                    Id = recipe.Id,
                    Title = recipe.Title,
                    Image = recipe.Image,
                    Ingredients = (List<CreateIngredientCommand>)recipe._ingredients.Select(t=>new IngredientViewModel
                    {
                        IngredientName =t.Ingredient,
                    })
                };
            }
            return null;
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
                    IngredientName = s.Ingredient,
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
                Ingredients = x._ingredients.ToList().Select(s => new CreateIngredientCommand
                {
                    IngredientName = s.Ingredient,
                }).ToList(),
            }).ToList();
        }
        public void Update(UpdateRecipeCommand Recipe)
        {
            var recipeUpdate = _reciperepository.FindRecipe(r => r.Id == Recipe.Id);
            if (recipeUpdate != null)
            {
                var updateobj = new Recipe(Recipe.Title, Recipe.Description, Recipe.Instructions, recipeUpdate.Image, Recipe.AuthorId, recipeUpdate.Id);
                _reciperepository.Update(updateobj);
            }
            else
                throw new NullReferenceException();
        }
    }
}
