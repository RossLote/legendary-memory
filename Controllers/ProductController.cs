using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using codingChallenge.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using AutoMapper;
using System.Diagnostics;

namespace codingChallenge.Controllers
{

    [Route("v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext _context;

        public ProductController(ProductContext context)
        {
            _context = context;
        }

        // GET v1/products
        /// <summary>
        /// Returns a list of products
        /// </summary>
        /// <remarks>
        /// Sample response:
        ///
        ///     [
        ///         {
        ///             "id": 1,
        ///             "name": "Product1",
        ///             "price": "1.99"
        ///         },
        ///         {
        ///             "id": 2,
        ///             "name": "Product2",
        ///             "price": "299"
        ///         }
        ///     ]
        ///
        /// </remarks>
        /// <returns>Product array</returns>
        /// <response code="200">Product array</response>
        [HttpGet]
        [Route("~/v1/[controller]s")]
        public ActionResult<IEnumerable<Product>> List()
        {
            return _context.Products;
        }

        // POST v1/products
        /// <summary>
        /// Creates a new product using posted form data
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST v1/product
        ///     {
        ///        "name": "Product1",
        ///        "price": 1.99
        ///     }
        ///
        /// Sample response:
        ///
        ///     {
        ///         "id": 1,
        ///         "name": "Product1",
        ///         "price": "1.99"
        ///     }
        ///
        /// </remarks>
        /// <returns>A newly created Product</returns>
        /// <response code="200">Returns the newly created Product</response>
        [HttpPost]
        public ActionResult<Product> Post([FromForm] Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        // GET v1/product/5
        /// <summary>
        /// Get a product by ID
        /// </summary>
        /// <remarks>
        ///
        /// Sample response:
        ///
        ///     {
        ///         "id": 1,
        ///         "name": "Product1",
        ///         "price": "1.99"
        ///     }
        ///
        /// </remarks>
        /// <param name="id">The id of the product</param>
        /// <returns>Returns a single product</returns>
        /// <response code="200">Returns a single product</response>
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var productItem = _context.Products.Find(id);

            if (productItem == null)
            {
                return NotFound();
            }

            return productItem;
        }

        // PUT v1/product/5
        /// <summary>
        /// Update a product's name or price by id.
        /// </summary>
        /// <remarks>
        ///
        /// Sample request:
        ///
        ///     {
        ///         "name": "New Product Name",
        ///     }
        ///
        /// Sample response:
        ///
        ///     {
        ///         "id": 1,
        ///         "name": "Product1",
        ///         "price": "1.99"
        ///     }
        ///
        /// </remarks>
        /// <param name="id">The id of the product</param>
        /// <param name="product">The product from the form data</param>
        /// <returns>Returns the updated product</returns>
        /// <response code="200">Returns the updated product</response>
        [HttpPut("{id}")]
        public ActionResult<Product> Put(int id, [FromForm] Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            var existingProduct = _context.Products.Find(id);

            if (existingProduct == null)
            {
                return NotFound();
            }

            if (product.Name != null)
                existingProduct.Name = product.Name;

            if (product.Price != null)
                existingProduct.Price = product.Price;

            _context.Entry(existingProduct).State = EntityState.Modified;
            _context.SaveChanges();

            return existingProduct;
        }

        // DELETE v1/products/5
        /// <summary>
        /// Deletes a product by id.
        /// </summary>
        /// <remarks>
        ///
        /// Sample response:
        ///
        ///     {
        ///         "id": 1,
        ///         "name": "Product1",
        ///         "price": "1.99"
        ///     }
        ///
        /// </remarks>
        /// <param name="id">The id of the product</param>
        /// <returns>Returns the deleted product</returns>
        /// <response code="200">Returns the deleted product</response>
        [HttpDelete("{id}")]
        public ActionResult<Product> Delete(int id)
        {
            var productItem = _context.Products.Find(id);

            if (productItem == null)
            {
                return NotFound();
            }

            _context.Products.Remove(productItem);
            _context.SaveChanges();

            return productItem;
        }
    }
}
