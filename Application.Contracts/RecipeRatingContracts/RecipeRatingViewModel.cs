namespace Application.Contracts.RecipeRatingContracts
{
    public class RecipeRatingViewModel : CreateRecipeRatingCommand
    {
        public int Id { get; set; }
        public bool IsRemoved { get; set; }
        public string AuthorUserName { get; set; }
    }
}
