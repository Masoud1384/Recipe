using Application.Contracts.RecipeContracts;
using Domain.Entities;
using System.Linq.Expressions;

namespace Application.Contracts.UserContracts
{
    public interface IUserApplication
    {
        List<UserViewMdoel> SelectAllUsers();
        UserViewMdoel FindRecipe(Expression<Func<User, bool>> expression);
        void DeActiveUser(int userI);
        void AddUser(CreateUserCommand user);
        void Update(UpdateUserCommand user);
        void ActivateUser(int userId);
    }
}
