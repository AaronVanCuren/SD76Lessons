using _14_GeneralStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace _14_GeneralStore.Controllers
{
    public class ProductController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();


        // C
        [HttpPost]
        public async Task<IHttpActionResult> CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest(ModelState);
        }

        // R
        [HttpGet]
        public async Task<IHttpActionResult> GetAllProducts()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetProductById(int id)
        {
            Product product = await _context.Products.FindAsync(id);
            if (product == default)
            {
                return NotFound(); // Code: 404
            }
            return Ok(product);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetProductByUPC(string upc)
        {
            List<UPCListItem> products = await _context.Products
                .Where(product => product.UPC == upc)
                .Select(product => new UPCListItem()
                {
                    Id = product.Id,
                    ProductName = product.ProductName,
                    UPC = product.UPC,
                    Price = product.Price,
                    Quantity = product.Quantity,
                }).ToListAsync();
            return Ok(products);
        }

        //U
        [HttpPut]
        public async Task<IHttpActionResult> UpdateProduct([FromUri] int id, [FromBody] ProductUpdate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400
            }
            var product = await _context.Products.FindAsync(id);
            if (product == default)
            {
                return NotFound(); // 404
            }
            if (!string.IsNullOrEmpty(model.ProductName))
            {
                product.ProductName = model.ProductName;
            }
            if (!string.IsNullOrEmpty(model.UPC))
            {
                product.UPC = model.UPC;
            }
            if (model.Price > 0)
            {
                product.Price = model.Price;
            }
            if (await _context.SaveChangesAsync() == 1)
            {
                return Ok(); // 200
            }
            return InternalServerError(); // 500
        }

        [HttpPut]
        [ActionName("Restock")]
        public async Task<IHttpActionResult> RestockProduct(int id, int amt)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == default)
            {
                return NotFound(); // 404
            }
            if (amt < 1)
            {
                return BadRequest("Amount must be at least 1");
            }
            product.Quantity += amt;
            await _context.SaveChangesAsync();
            return Ok($"{amt} {product.ProductName} added.");
        }
    }

    // D
    //[HttpDelete]
}
