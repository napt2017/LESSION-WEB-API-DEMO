using System.Linq;
using LESSION_WEB_API_DEMO.DataAccess;
using LESSION_WEB_API_DEMO.Models;

namespace LESSION_WEB_API_DEMO.Repositories
{
    public interface IUserRepository
    {
        IQueryable<User> GetAll();
        User FindUserById(int id);
        void InsertUser(User user);
        bool IsExist(int id);
    }

    public class UserRepository : IUserRepository
    {
        private readonly ProductManagementDbContext _dbContext;

        public UserRepository(ProductManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User FindUserById(int id)
        {
            return _dbContext.Users.Find(id);
        }

        public IQueryable<User> GetAll()
        {
            return _dbContext.Users;
        }

        public void InsertUser(User user)
        {
            _dbContext.Users.Add(user);
        }

        public bool IsExist(int id)
        {
            return _dbContext.Users.Find(id) != null;
        }
    }
}