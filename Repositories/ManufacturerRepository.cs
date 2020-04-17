using System; 
using System.Linq;
using LESSION_WEB_API_DEMO.DataAccess;
using LESSION_WEB_API_DEMO.Models;

namespace LESSION_WEB_API_DEMO.Repositories
{
    public interface IManufacturerRepository
    {
        IQueryable<Manufacturer> GetAll();
        Manufacturer FindManufacturerById(int id);
        Manufacturer UpdateManufacturer(int id, Manufacturer updateManufacturer);
        void InsertManufacturer(Manufacturer manufacturer);
        Manufacturer DeleteManufacturer(int id);
        bool IsExist(int id);
    }

    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly ProductManagementDbContext _dbContext;

        public ManufacturerRepository(ProductManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Manufacturer DeleteManufacturer(int id)
        {
            var manufacturerFollowId = _dbContext.Manufacturers.Find(id);
            if (manufacturerFollowId != null)
            {
                _dbContext.Manufacturers.Remove(manufacturerFollowId);
                _dbContext.SaveChanges();
            }
            return manufacturerFollowId;
        }

        public Manufacturer FindManufacturerById(int id)
        {
            return _dbContext.Manufacturers.Find(id);
        }

        public IQueryable<Manufacturer> GetAll()
        {
            return _dbContext.Manufacturers;
        }

        public void InsertManufacturer(Manufacturer manufacturer)
        {
            _dbContext.Manufacturers.Add(manufacturer);
            _dbContext.SaveChanges();
        }

        public bool IsExist(int id)
        {
            return _dbContext.Manufacturers.Find(id) != null;
        }

        public Manufacturer UpdateManufacturer(int id, Manufacturer updateManufacturer)
        {
            var manufacturerFollowId = _dbContext.Manufacturers.Find(id);
            if (manufacturerFollowId != null)
            {
                manufacturerFollowId.Address = updateManufacturer.Address;
                manufacturerFollowId.Name = updateManufacturer.Name;
                //manufacturerFollowId.Products = updateManufacturer.Products;
                //manufacturerFollowId.Id = updateManufacturer.Id;
                _dbContext.SaveChanges();
            }
            return manufacturerFollowId;
        }
    }
}