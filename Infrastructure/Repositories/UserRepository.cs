﻿using Domain.Entities;
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
            return _context.users.FirstOrDefault(expression);
        }

        public void Update(User user)
        {
            var User = Get(user.Id);
            User.Edit(user.Username,user.Email);
            User.ChangePassword(user.Password);
            _context.SaveChanges();
        }

        public List<User> users(Expression<Func<User, bool>> expression)
        {
            return _context.users.Where(expression).ToList();
        }
    }
}
