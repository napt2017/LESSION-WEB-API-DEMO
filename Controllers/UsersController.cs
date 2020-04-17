using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using LESSION_WEB_API_DEMO.DataAccess;
using LESSION_WEB_API_DEMO.Models;
using LESSION_WEB_API_DEMO.Repositories;

namespace LESSION_WEB_API_DEMO.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }         

        // GET: api/Users
        public IQueryable<User> GetUsers()
        {
            return _userRepository.GetAll();
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = _userRepository.FindUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _userRepository.InsertUser(user);
            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        } 

        private bool UserExists(int id)
        {
            return _userRepository.IsExist(id);
        }
    }
}