using Application;
using Application.Contracts.RecipeContracts;
using Application.Contracts.RecipeIngredientContracts;
using Application.Contracts.RecipeRatingContracts;
using Application.Contracts.UserContracts;
using Domain.Repositories;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configuration
{
    public class Bootstraper
    {
        public static void Configure(IServiceCollection service)
        {
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IRecipeRatingRepository, RecipeRatingRepository>();
            service.AddScoped<IRecipeRepository, RecipeRepository>();
            service.AddScoped<IRecipeIngredientRepository, RecipeIngradientRepository>();

            service.AddScoped<IRecipeApplication, RecipeApplication>();
            service.AddScoped<IUserApplication, UserApplication>();
            service.AddScoped<IRecipeRatingApplication, RecipeRatingApplication>();
            service.AddScoped<IRecipeIngredientApplication, RecipeIngradientApplication>();
        }
    }
}
