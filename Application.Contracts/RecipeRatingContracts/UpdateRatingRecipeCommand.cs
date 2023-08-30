namespace Application.Contracts.RecipeRatingContracts
{
    public class UpdateRatingRecipeCommand:CreateRecipeRatingCommand
    {
        public int Id { get; set; }
    }
}
