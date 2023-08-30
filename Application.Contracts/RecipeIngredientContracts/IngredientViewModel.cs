namespace Application.Contracts.RecipeIngredientContracts
{
    public class IngredientViewModel : CreateIngredientCommand
    {
        public int Id { get; set; }
        public string RecipeName { get; set; }
    }
}
