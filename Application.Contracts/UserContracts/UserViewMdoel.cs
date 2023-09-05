using Domain.Entities;

namespace Application.Contracts.UserContracts
{
    public class UserViewMdoel : CreateUserCommand
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public List<UserRoles> Roles { get; set; }
    }
}
