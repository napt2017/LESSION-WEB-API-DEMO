using System.Net; 
using System.Linq;
using System.Web.Http; 
using System.Web.Http.Description; 

using LESSION_WEB_API_DEMO.Models;
using LESSION_WEB_API_DEMO.Repositories;

namespace LESSION_WEB_API_DEMO.Controllers
{
    public class RolesController : ApiController
    {
        private readonly IRoleRepository _roleRepository;

        public RolesController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        // GET: api/Roles
        public IQueryable<Role> GetRoles()
        {
            return _roleRepository.GetAll();
        }

        // GET: api/Roles/5
        [ResponseType(typeof(Role))]
        public IHttpActionResult GetRole(int id)
        {
            Role role = _roleRepository.FindRoleById(id);
            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        // PUT: api/Roles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRole(int id, Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != role.Id)
            {
                return BadRequest();
            }

            var updatedRole = _roleRepository.UpdateRole(id, role);
            if (updatedRole == null)
            {
                return NotFound();
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Roles
        [ResponseType(typeof(Role))]
        public IHttpActionResult PostRole(Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _roleRepository.InsertRole(role);
            return CreatedAtRoute("DefaultApi", new { id = role.Id }, role);
        }

        // DELETE: api/Roles/5
        [ResponseType(typeof(Role))]
        public IHttpActionResult DeleteRole(int id)
        {
            Role role = _roleRepository.DeleteRole(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        private bool RoleExists(int id)
        {
            return _roleRepository.IsExist(id);
        }
    }
}