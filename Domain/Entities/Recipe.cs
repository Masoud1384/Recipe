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
        public Recipe(string title, string description, string instructions, int authorId , int id = 0)
        {
            Title = title;
            Description = description;
            Instructions = instructions;
            IsRemoved = false;
            AuthorId = authorId;
            if (id != 0)
                this.Id = id;
        }
        public void EditIngrediant(List<RecipeIngredient> recipeIngredients)
        {
            this._ingredients = recipeIngredients;
        }
        public void Delete()
        {
            IsRemoved = true;
        }
        public void Restore()
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
        public void Update(Recipe recipe)
        {
            this.Title = recipe.Title;
            this.Description = recipe.Description;
            this.Instructions = recipe.Instructions;
        }

        public List<RecipeIngredient> FetchIngredients()
        {
            return (List<RecipeIngredient>)this._ingredients;
        }
    }
}
