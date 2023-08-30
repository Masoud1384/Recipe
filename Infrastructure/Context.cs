using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            :base(options)
        {

        }

        public DbSet<User> users { get; set; }
        public DbSet<Recipe> recipes { get; set; }
        public DbSet<RecipeIngredient> ingredients { get; set; }
        public DbSet<RecipeRating> ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var assembly = typeof(Mapping.UserMapping).Assembly;
            builder.ApplyConfigurationsFromAssembly(assembly);
        }

    }
}
