using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class RecipeIngredientMapping : IEntityTypeConfiguration<RecipeIngredientMapping>
    {
        public void Configure(EntityTypeBuilder<RecipeIngredientMapping> builder)
        {
            throw new NotImplementedException();
        }
    }
}
