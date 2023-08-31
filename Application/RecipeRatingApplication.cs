using Application.Contracts.RecipeContracts;
using Application.Contracts.RecipeRatingContracts;
using Domain.Entities;
using Domain.Repositories;
using System.Linq.Expressions;

namespace Application
{
    public class RecipeRatingApplication : IRecipeRatingApplication
    {
        private IRecipeRatingRepository _ratingRepository;

        public RecipeRatingApplication(IRecipeRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }
        public void ActivateRating(int ratingId)
        {
            var rating = _ratingRepository.Get(ratingId);
            if (rating != null)
            {
                rating.Restore();
                _ratingRepository.SaveChanges();
            }
        }

        public void AddRating(CreateRecipeRatingCommand rating)
        {
            var recipe = new RecipeRating(rating.Rating, rating.RecipeId);
            _ratingRepository.Create(recipe);
            _ratingRepository.SaveChanges();
        }

        public void Delete(int ratingId)
        {
            var rating = _ratingRepository.Get(ratingId);
            if (rating != null)
            {
                rating.Remove();
                _ratingRepository.SaveChanges();
            }
        }

        public RecipeRatingViewModel FindRecipe(Expression<Func<RecipeRating, bool>> expression)
        {
            var rating = _ratingRepository.FindRating(expression);
            return new RecipeRatingViewModel
            {
                AuthorId = rating.UserId,
                Id = rating.Id,
                IsRemoved = rating.IsRemoved,
                Rating = rating.Rating,
                RecipeId = rating.RecipeId,
            };
        }

        public List<RecipeRatingViewModel> SelectAllRecipes()
        {
            return _ratingRepository.Get().Select(x => new RecipeRatingViewModel
            {
                AuthorId = x.UserId,
                Id = x.Id,
                IsRemoved = x.IsRemoved,
                Rating = x.Rating,
                RecipeId = x.RecipeId,
            }).OrderByDescending(x => x.Id).ToList();
        }

        public void Update(UpdateRatingRecipeCommand ratingcmd)
        {
            var rating = _ratingRepository.FindRating(r => r.Id == ratingcmd.Id);
            if (rating != null)
            {
                var updateobj = new RecipeRating(rating.Rating,rating.RecipeId,rating.Id);
                _ratingRepository.Update(updateobj);
            }
            else
                throw new NullReferenceException();
        }
    }
}
