using Application.Contracts.RecipeIngredientContracts;
using Application.Contracts.UserContracts;
using Domain.Entities;
using Domain.Repositories;
using System.Linq.Expressions;

namespace Application
{
    public class UserApplication : IUserApplication
    {
        private IUserRepository _userRepository;

        public UserApplication(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void ActivateUser(int userId)
        {
            var user = _userRepository.Get(userId);
            if (user != null)
            {
                user.Activate();
                _userRepository.SaveChanges();
            }
        }

        public void AddUser(CreateUserCommand usercmd)
        {
            var user = new User(usercmd.Username, usercmd.Email, usercmd.Password);
            _userRepository.Create(user);
            _userRepository.SaveChanges();
        }

        public void DeActiveUser(int userId)
        {
            var user = _userRepository.Get(userId);
            if (user != null)
            {
                user.DeActive();
                _userRepository.SaveChanges();
            }
        }

        public UserViewMdoel FindRecipe(Expression<Func<User, bool>> expression)
        {
            var user = _userRepository.FindUser(expression);
            return new UserViewMdoel
            {
                IsActive = user.IsActive,
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
            };
        }

        public List<UserViewMdoel> SelectAllUsers()
        {
            return _userRepository.Get().Select(t => new UserViewMdoel
            {
                Id = t.Id,
                IsActive = t.IsActive,
                Email = t.Email,
                Password = t.Password,
                Username = t.Username,
            }).OrderByDescending(t => t.Id).ToList();
        }

        public void Update(UpdateUserCommand usercmd)
        {
            var user = _userRepository.FindUser(r => r.Id == usercmd.Id);
            if (user != null)
            {
                var updateobj = new User(usercmd.Username,usercmd.Email,usercmd.Password,usercmd.Id);
                _userRepository.Update(updateobj);
            }
            else
                throw new NullReferenceException();
        }
    }
}
