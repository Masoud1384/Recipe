using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Mapping
{
    public class RecipeRatingMapping : IEntityTypeConfiguration<RecipeRating>
    {
        public void Configure(EntityTypeBuilder<RecipeRating> builder)
        {
            throw new NotImplementedException();
        }
    }
}
