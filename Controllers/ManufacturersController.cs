using System.Net; 
using System.Linq;
using System.Web.Http; 
using System.Web.Http.Description;

using LESSION_WEB_API_DEMO.Models;
using LESSION_WEB_API_DEMO.Repositories;

namespace LESSION_WEB_API_DEMO.Controllers
{
    public class ManufacturersController : ApiController
    {
        private readonly IManufacturerRepository _manufacturerRepository;

        public ManufacturersController(IManufacturerRepository manufacturerRepository)
        {
            _manufacturerRepository = manufacturerRepository;
        }

        // GET: api/Manufacturers
        public IQueryable<Manufacturer> GetManufacturers()
        {
            return _manufacturerRepository.GetAll();
        }

        // GET: api/Manufacturers/5
        [ResponseType(typeof(Manufacturer))]
        public IHttpActionResult GetManufacturer(int id)
        {
            Manufacturer manufacturer = _manufacturerRepository.FindManufacturerById(id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            return Ok(manufacturer);
        }

        // PUT: api/Manufacturers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutManufacturer(int id, Manufacturer manufacturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != manufacturer.Id)
            {
                return BadRequest();
            }

            var updatedManufacturer = _manufacturerRepository.UpdateManufacturer(id, manufacturer);
            if (updatedManufacturer == null)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Manufacturers
        [ResponseType(typeof(Manufacturer))]
        public IHttpActionResult PostManufacturer(Manufacturer manufacturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _manufacturerRepository.InsertManufacturer(manufacturer);

            return CreatedAtRoute("DefaultApi", new { id = manufacturer.Id }, manufacturer);
        }

        // DELETE: api/Manufacturers/5
        [ResponseType(typeof(Manufacturer))]
        public IHttpActionResult DeleteManufacturer(int id)
        {
            Manufacturer manufacturer = _manufacturerRepository.DeleteManufacturer(id);
            if (manufacturer == null)
            {
                return NotFound();
            }
            return Ok(manufacturer);
        }

        private bool ManufacturerExists(int id)
        {
            return _manufacturerRepository.IsExist(id);
        }
    }
}