using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Repositories
{
    public interface IUserServices
    {
        List<User> SelectAllUsers();
        User FindUser(Expression<Func<User, bool>> expression);
        bool DeleteUser(int UserId);
        bool AddUser(User User, string email, string fullname);
        bool Update(User User);
        void ActivateUser(int UserId);
    }
}
