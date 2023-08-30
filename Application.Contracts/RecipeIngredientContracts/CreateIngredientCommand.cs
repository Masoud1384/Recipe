namespace Application.Contracts.RecipeIngredientContracts
{
    public class CreateIngredientCommand
    {
        public string IngredientName { get; set; }
        public string Quantity { get; set; }
        public int RecipeId { get; set; }
    }
}
