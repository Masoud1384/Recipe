using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class RecipeIngredientMapping : IEntityTypeConfiguration<RecipeIngredient>
    {
        public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
        {
            builder.HasKey(t=>t.Id);
            builder.Property(i => i.Quantity)
                .IsRequired()
                .HasMaxLength(128);
            builder.Property<DateTime>("ingredient_add_date")
                .HasDefaultValue(DateTime.Now);
            builder.Property(i=>i.IngredientName)
                .IsRequired()
                .HasMaxLength(128);
        }
    }
}
