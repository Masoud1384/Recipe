﻿using Application.Contracts.RecipeContracts;
using Application.Contracts.RecipeRatingContracts;
using Domain.Entities;
using System.Linq.Expressions;

namespace Application
{
    public class RecipeRatingApplication : IRecipeRating
    {
        public void ActivateRecipe(int RecipeId)
        {
            throw new NotImplementedException();
        }

        public bool AddRecipe(CreateRecipeRatingCommand Recipe)
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