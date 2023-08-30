namespace Application.Contracts.UserContracts
{
    public class CreateUserCommand
    {
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
    }
}
