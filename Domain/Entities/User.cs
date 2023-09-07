namespace Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool IsActive { get; private set; }

        public ICollection<Recipe> _createdRecipes { get; set; }
        public ICollection<UserRoles> roles { get; private set; }
        private User() { }
        public User(string username, string email, string password, int id = 0)
        {
            this.Username = username;
            this.Email = email;
            this.Password = password;
            this.IsActive = true;
            this.roles = new List<UserRoles>();
            if (id > 0)
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

        public void AssignRole(UserRoles role)
        {
            this.roles.Add(role);
        }

        public Recipe CreateRecipe(string title, string description, string instructions,string image)
        {
            var recipe = new Recipe(title, description, instructions,image, this.Id);
            _createdRecipes.Add(recipe);
            return recipe;
        }
        public IReadOnlyCollection<Recipe> GetCreatedRecipes()
        {
            return _createdRecipes.ToList().AsReadOnly();
        }
    }

}
