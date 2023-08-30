namespace Application.Contracts.RecipeContracts
{
    public class CreateRecipeCommand
    {
        public string Title { get;  set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public int AuthorId { get; set; }
    }
}
