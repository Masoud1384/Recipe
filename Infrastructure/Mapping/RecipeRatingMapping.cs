using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Mapping
{
    public class RecipeRatingMapping : IEntityTypeConfiguration<RecipeRating>
    {
        public void Configure(EntityTypeBuilder<RecipeRating> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(r => r.Rating)
                .IsRequired()
                .HasColumnType("tinyint")
                .HasColumnName("recipe_rate");
            builder.Property<DateTime>("rate_confirmed_date")
                .HasDefaultValue(DateTime.Now);
            builder.Property(r => r.IsRemoved)
                .IsRequired()
                .HasConversion(new BoolToStringConverter("Active", "NotAcive"));
        }
    }
}
