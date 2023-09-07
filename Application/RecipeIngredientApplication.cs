using Application.Contracts.RecipeContracts;
using Application.Contracts.RecipeIngredientContracts;
using Domain.Entities;
using Domain.Repositories;
using System.Linq.Expressions;

namespace Application
{
    public class RecipeIngredientApplication : IRecipeIngredientApplication
    {
        private IRecipeIngredientRepository _ingradientRepository;

        public RecipeIngredientApplication(IRecipeIngredientRepository ingradientRepository)
        {
            _ingradientRepository = ingradientRepository; 
        }

        public void ActivateIngredient(int IngredientId)
        {
            var ingredient = _ingradientRepository.Get(IngredientId);
            if (ingredient != null)
            {
                ingredient.Restore();
                _ingradientRepository.SaveChanges();
            }
        }

        public void AddIngredient(CreateIngredientCommand createIngredientcommand)
        {
            var ingredient = new RecipeIngredient(createIngredientcommand.IngredientName, createIngredientcommand.RecipeId);
            _ingradientRepository.Create(ingredient);
            _ingradientRepository.SaveChanges();
        }

        public void Delete(int IngredientId)
        {
            var ingredient = _ingradientRepository.Get(IngredientId);
            if (ingredient != null)
            {
                ingredient.Remove();
                _ingradientRepository.SaveChanges();
            }
        }

        public IngredientViewModel FindIngredient(Expression<Func<RecipeIngredient, bool>> expression)
        {
            var recipe = _ingradientRepository.FindIngredient(expression);
            return new IngredientViewModel
            {
                RecipeId = recipe.Id,
                Id = recipe.Id,
                IngredientName = recipe.Ingredient,
            };
        }

        public List<IngredientViewModel> SelectAllIngredient()
        {
            return _ingradientRepository.Get().Select(t=> new IngredientViewModel
            {
                Id = t.Id,
                IngredientName =t.Ingredient,
                RecipeId = t.RecipeId,
            }).OrderByDescending(t => t.Id).ToList();
        }

        public void Update(UpdateIngredientCommand ingredient)
        {
            var recipeUpdate = _ingradientRepository.Get(ingredient.Id);
            if (recipeUpdate != null)
            {

                var updateIngredient = new RecipeIngredient(ingredient.IngredientName,ingredient.Id);
                _ingradientRepository.Update(updateIngredient);
            }
            else
                throw new NullReferenceException();
        }

    }
}
