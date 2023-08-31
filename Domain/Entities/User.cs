namespace Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool IsActive { get; private set; }

        private ICollection<Recipe> _createdRecipes = new List<Recipe>();
        private ICollection<RecipeRating> _ratedRecipes = new List<RecipeRating>();
        private User() { }
        public User(string username, string email, string password,int id = 0)
        {
            this.Username = username;
            this.Email = email;
            this.Password = password;
            this.IsActive = true;
            if(id > 0)
                this.Id = id;
        }
        public void Edit(string username, string email)
        {
            Username = username;
            Email = email;
        }

        public void ChangePassword(string newPasswrod)
        {
            this.Password = newPasswrod;
        }
        public void DeActive()
        {
            IsActive = false;
        }
        public void Activate()
        {
            IsActive = true;
        }

        public Recipe CreateRecipe(string title, string description, string instructions)
        {
            var recipe = new Recipe(title, description, instructions, this.Id);
            _createdRecipes.Add(recipe);
            return recipe;
        }
        public void RateRecipe(RecipeRating rating)
        {
            _ratedRecipes.Add(rating);
        }
        public IReadOnlyCollection<Recipe> GetCreatedRecipes()
        {
            return _createdRecipes.ToList().AsReadOnly();
        }
        public IReadOnlyCollection<RecipeRating> GetRatedRecipes()
        {
            return _ratedRecipes.ToList().AsReadOnly();
        }
    }

}
