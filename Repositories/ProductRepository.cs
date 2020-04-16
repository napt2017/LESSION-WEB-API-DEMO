using LESSION_WEB_API_DEMO.DataAccess;
using LESSION_WEB_API_DEMO.Models;
using System.Linq;

namespace LESSION_WEB_API_DEMO.Repositories
{
    public interface IProductRepository
    {
        IQueryable<Product> GetAll();
        Product FindProductById(int id);
        Product UpdateProduct(int id, Product updateProduct);
        void InsertProduct(Product product);
        Product DeleteProduct(int id);
        bool IsExist(int id);
    }

    public class ProductRepository : IProductRepository
    {
        private readonly ProductManagementDbContext _dbContext;

        public ProductRepository(ProductManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Product DeleteProduct(int id)
        {
            var product = _dbContext.Products.Find(id);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges(); 
            }
            return product;            
        }

        public Product FindProductById(int id)
        {
            var product =  _dbContext.Products.Find(id);
            if (product != null && product.Manufacturer !=null)
            {
                product.Manufacturer.Products = new System.Collections.ObjectModel.Collection<Product>();
            }
            return product;
        }

        public IQueryable<Product> GetAll()
        {
            return _dbContext.Products;
        }

        public void InsertProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }

        public bool IsExist(int id)
        {
            return _dbContext.Products.Find(id) != null;
        }

        public Product UpdateProduct(int id, Product updateProduct)
        {
            var productInDb = _dbContext.Products.Find(id);
            if (productInDb != null)
            {
                productInDb.Description = updateProduct.Description;
                productInDb.Name = updateProduct.Name;
                productInDb.Price = updateProduct.Price;
                productInDb.Quantity = updateProduct.Quantity;
                productInDb.ManufacturerId = updateProduct.ManufacturerId;
                _dbContext.SaveChanges();
                return productInDb;
            }
            return null;
        }
    }
}