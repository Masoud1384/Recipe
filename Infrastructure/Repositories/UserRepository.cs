using Domain.Entities;
using Domain.Repositories;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }
        public void ActivateUser(int UserId)
        {
            throw new NotImplementedException();
        }

        public bool AddUser(User User, string email, string fullname)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(int UserId)
        {
            throw new NotImplementedException();
        }

        public User FindUser(Expression<Func<User, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public List<User> SelectAllUsers()
        {
            throw new NotImplementedException();
        }

        public bool Update(User User)
        {
            throw new NotImplementedException();
        }
    }
}
