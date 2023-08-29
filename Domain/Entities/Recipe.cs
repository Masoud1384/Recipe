namespace Domain.Entities
{
    public class Recipe
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Instructions { get; private set; }
        public bool IsRemoved { get; private set; }
        public int AuthorId { get; private set; }
        public User Author { get; private set; }

        private ICollection<RecipeIngredient> _ingredients = new List<RecipeIngredient>();
        public ICollection<RecipeRating>? _ratings { get; private set; }
        private Recipe() { }
        public Recipe(string title, string description, string instructions, int authorId)
        {
            Title = title;
            Description = description;
            Instructions = instructions;
            CreatedAt = DateTime.UtcNow;
            IsRemoved = false;
            AuthorId = authorId;
        }
        public void Edit(string title, string description, string instructions)
        {
            Title = title;
            Description = description;
            Instructions = instructions;
        }
        public void EditIngrediant(List<RecipeIngredient> recipeIngredients)
        {
            this._ingredients = recipeIngredients;
        }
        public void MarkAsRemoved()
        {
            IsRemoved = true;
        }
        public void AddIngredient(RecipeIngredient ingredient)
        {
            _ingredients.Add(ingredient);
        }
        public void AddRating(RecipeRating rating)
        {
            _ratings.Add(rating);
        }
        public List<RecipeIngredient> FetchIngredients()
        {
            return (List<RecipeIngredient>)this._ingredients;
        }
    }
}
