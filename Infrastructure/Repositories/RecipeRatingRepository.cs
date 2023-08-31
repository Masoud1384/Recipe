﻿using Domain.Entities;
using Domain.Repositories;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class RecipeRatingRepository : Repository<int, RecipeRating>, IRecipeRatingRepository
    {
        private Context _context;

        public RecipeRatingRepository(Context context)
            :base(context)
        {
            _context = context;
        }

        public RecipeRating FindRating(Expression<Func<RecipeRating, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public List<RecipeRating> Ratings(Expression<Func<Recipe, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Update(RecipeRating recipeRating)
        {
            throw new NotImplementedException();
        }
    }
}
