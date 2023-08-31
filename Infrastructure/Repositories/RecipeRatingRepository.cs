using Domain.Entities;
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
            return _context.ratings.FirstOrDefault(expression);
        }

        public List<RecipeRating> Ratings(Expression<Func<RecipeRating, bool>> expression)
        {
            return _context.ratings.Where(expression).ToList();
        }

        public void Update(RecipeRating recipeRating)
        {
            var rating = Get(recipeRating.Id);
            rating.Edit(rating.Rating);
            _context.SaveChanges();
        }
    }
}
