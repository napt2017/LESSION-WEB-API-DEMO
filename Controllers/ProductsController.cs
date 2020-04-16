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
    public class ProductsController : ApiController
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        } 

        // GET: api/Products
        public IQueryable<Product> GetProducts()
        {
            return _productRepository.GetAll();
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            //Product product = db.Products.Find(id);
            var product = _productRepository.FindProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

            _productRepository.UpdateProduct(id, product);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _productRepository.InsertProduct(product);

            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            var deletedProduct = _productRepository.DeleteProduct(id);
            if (deletedProduct == null)
            {
                return NotFound();
            } 
            return Ok(deletedProduct);
        }

        private bool ProductExists(int id)
        {
            return _productRepository.IsExist(id);
        }
    }
}