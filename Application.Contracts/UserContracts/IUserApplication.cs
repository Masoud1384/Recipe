using Application.Contracts.RecipeContracts;
using Domain.Entities;
using System.Linq.Expressions;

namespace Application.Contracts.UserContracts
{
    public interface IUserApplication
    {
        List<UserViewMdoel> SelectAllUsers();
        UserViewMdoel FindUser(Expression<Func<User, bool>> expression);
        bool DeActiveUser(int userI);
        bool AddUser(CreateUserCommand user);
        bool Update(UpdateUserCommand user);
        bool ActivateUser(int userId);
        void AddRoleToUser(int userId,string role);
    }
}
