using System.Linq;
using LESSION_WEB_API_DEMO.DataAccess;
using LESSION_WEB_API_DEMO.Models;

namespace LESSION_WEB_API_DEMO.Repositories
{
    public interface IRoleRepository
    {
        IQueryable<Role> GetAll();
        Role FindRoleById(int id);
        Role UpdateRole(int id, Role updateRole);
        void InsertRole(Role role);
        Role DeleteRole(int id);
        bool IsExist(int id);
    }

    public class RoleRepository : IRoleRepository
    {
        private readonly ProductManagementDbContext _dbContext;

        public RoleRepository(ProductManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Role DeleteRole(int id)
        {
            var roleFollowId = _dbContext.Roles.Find(id);
            if (roleFollowId != null)
            {
                _dbContext.Roles.Remove(roleFollowId);
                _dbContext.SaveChanges();
            }
            return roleFollowId;
        }

        public Role FindRoleById(int id)
        {
            return _dbContext.Roles.Find(id);
        }

        public IQueryable<Role> GetAll()
        {
            return _dbContext.Roles;
        }

        public void InsertRole(Role role)
        {
            _dbContext.Roles.Add(role);
            _dbContext.SaveChanges();
        }

        public bool IsExist(int id)
        {
            return _dbContext.Roles.Find(id) != null;
        }

        public Role UpdateRole(int id, Role updateRole)
        {
            var roleFollowId = _dbContext.Roles.Find(id);
            if (roleFollowId != null)
            {
                roleFollowId.Name = updateRole.Name;
                _dbContext.SaveChanges();
            }
            return roleFollowId;
        }
    }
}