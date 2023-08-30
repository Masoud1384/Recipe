using Domain.Entities;
using Domain.Repositories;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class RecipeRatingRepository : IRecipeRatingRepository
    {
        private Context _context;

        public RecipeRatingRepository(Context context)
        {
            _context = context;
        }

        public void ActivateRecipe(int RateId)
        {
            throw new NotImplementedException();
        }

        public bool AddRecipe(RecipeRating RecipeRating)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRecipe(int RateId)
        {
            throw new NotImplementedException();
        }

        public Recipe FindRating(Expression<Func<RecipeRating, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public List<RecipeRating> SelectAllRatings()
        {
            throw new NotImplementedException();
        }

        public bool Update(RecipeRating RecipeRating)
        {
            throw new NotImplementedException();
        }
    }
}
