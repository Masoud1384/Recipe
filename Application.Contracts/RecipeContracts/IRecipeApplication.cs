﻿using Domain.Entities;
using System.Linq.Expressions;

namespace Application.Contracts.RecipeContracts
{
    public interface IRecipeApplication
    {
        List<Recipe> SelectAllRecipes();
        Recipe FindRecipe(Expression<Func<Recipe, bool>> expression);
        bool DeleteRecipe(int RecipeId);
        bool AddRecipe(CreateRecipeCommand Recipe);
        bool Update(UpdateRecipeCommand Recipe);
        void ActivateRecipe(int RecipeId);
    }
}
