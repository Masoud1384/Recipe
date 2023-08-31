using Domain.Entities;
using Domain.Repositories;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class UserRepository : Repository<int, User>, IUserRepository
    {
        private Context _context;

        public UserRepository(Context context)
            : base(context)
        {
            _context = context;
        }
        public User FindUser(Expression<Func<User, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }

        public List<User> users(Expression<Func<User, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
