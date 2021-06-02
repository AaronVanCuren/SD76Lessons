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
    public class CustomerController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        // C
        [HttpPost]
        public async Task<IHttpActionResult> CreateCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest(ModelState);
        }

        // R
        [HttpGet]
        public async Task<IHttpActionResult> GetAllCustomers()
        {
            List<Customer> customers = await _context.Customers.ToListAsync();
            return Ok(customers);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetCustomerById(int id)
        {
            Customer customer = await _context.Customers.FindAsync(id);
            if (customer == default)
            {
                return NotFound(); // Code: 404
            }
            return Ok(customer);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetCusomterByName(string firstName, string lastName)
        {
            List<Customer> customers = await _context.Customers.Where(c => c.FirstName == firstName && c.LastName == lastName).ToListAsync();
            return Ok(customers);
        }

            //U
            //[HttpPut]

            // D
            //[HttpDelete]
    }
}
