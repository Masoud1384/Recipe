using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Mapping
{
    public class RecipeMapping : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property<DateTime>("RegisterDate")
               .HasDefaultValue(DateTime.Now);
            builder.Property(r => r.Title)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(r => r.Description)
                .IsRequired()
                .HasMaxLength(100)
                .HasDefaultValue("This is the best recipe that you can find");
            builder.Property(r=>r.Instructions)
                .IsRequired();
            builder.Property(r => r.IsRemoved)
                .HasConversion(new BoolToStringConverter("Active","Not Active"))
                .IsRequired();
        }
    }
}
