namespace Domain.Entities
{
    public class RecipeIngredient
    {
        public int Id { get; private set; }
        public string IngredientName { get; private set; }
        public string Quantity { get; private set; }
        public bool IsRemoved { get; private set; }
        public int RecipeId { get; private set; }
        public Recipe Recipe { get; private set; }
        private RecipeIngredient()
        {
            
        }
        public RecipeIngredient(string ingredientName, string quantity, int recipeId)
        {
            IngredientName = ingredientName;
            Quantity = quantity;
            RecipeId = recipeId;
            IsRemoved = false;
        }
        public void Remove()
        {
            this.IsRemoved = true;
        }
        public void Restore()
        {
            this.IsRemoved = false;
        }
        public void Edit(string name, string quantity)
        {
            this.IngredientName = name;
            this.Quantity = quantity;
        }
    }
}
