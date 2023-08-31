using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text;

namespace Infrastructure.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .UseIdentityColumn(1000, 1);
            builder.Property<DateTime>("RegisterDate")
                .HasDefaultValue(DateTime.Now);
            builder.HasIndex(u => u.Username)
                .IsUnique(true);
            builder.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("varchar")
                //.HasConversion(v => v.ToString(),v => Guid.Parse(v).ToString());
                .HasConversion(u => Encode(u), u => DeCode(u));
            builder.Property(u => u.Email)
                .IsRequired()
                .HasConversion(u => Encode(u), u => DeCode(u));
            builder.Property(u=>u.IsActive)
                .IsRequired()
                .HasConversion(new BoolToStringConverter("DeActive","Active"));


        }
        public static string Encode(string text)
        {
            var encoded = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(encoded);
        }
        public static string DeCode(string encoded)
        {
            var text = Convert.FromBase64String(encoded);
            return Encoding.UTF8.GetString(text);
        }
    }
}
