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
    public class TransactionController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        // C
        [HttpPost]
        public async Task<IHttpActionResult> PurchaseProduct(Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Transactions.Add(transaction);

            var product = await _context.Products.FindAsync(transaction.ProductId);
            product.Quantity -= transaction.Quantity;
            if (product.Quantity < transaction.Quantity)
            {
                return BadRequest("We don't have that many in stock");
            }

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAllTransactions()
        {
            var transactions = await _context.Transactions.ToListAsync();
            return Ok(transactions);
        }
    }
}
