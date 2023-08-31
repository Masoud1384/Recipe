namespace Domain.Entities
{
    public class RecipeRating
    {
        public int Id { get;private set; }
        public byte Rating { get; private set; }
        public bool IsRemoved { get; private set; }
        public int UserId { get; private set; }
        public User User { get; private set; }
        public int RecipeId { get; private set; }
        public Recipe Recipe { get; set; }
        private RecipeRating()
        {

        }
        public RecipeRating(byte rating,int recipeId,int id = 0)
        {
            this.Rating = rating;
            RecipeId = recipeId;
            IsRemoved = false;
            if (id > 0) 
                this.Id= id;
        }
        public void Remove()
        {
            this.IsRemoved = true;
        }
        public void Restore()
        {
            this.IsRemoved = false;
        }
        public void Edit(byte rating)
        {
            this.Rating = rating;
        }
    }
}
