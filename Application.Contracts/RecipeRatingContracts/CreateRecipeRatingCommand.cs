namespace Application.Contracts.RecipeRatingContracts
{
    public class CreateRecipeRatingCommand
    {
        public byte Rating { get; set; }
        public int AuthorId { get; set; }
        public int RecipeId { get; set; }
    }
}
