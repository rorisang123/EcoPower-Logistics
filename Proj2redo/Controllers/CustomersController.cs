using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Proj2redo.Data;
using Proj2redo.Models;
using System.Web.Mvc;
using System.Web.Http.Results;

namespace Proj2redo.Controllers
{
    public class CustomersController : ApiController
    {

        private Proj2redoContext db = new Proj2redoContext();

        // GET: api/Customers
        public List<Customer> GetCustomers()
        {
            return db.Customers.ToList();
        }

        // GET: api/Customers/5
        [ResponseType(typeof(Customer))]
        public async Task<IHttpActionResult> GetCustomer(int id)
        {
            Customer customer = await db.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }



            return Ok(customer);
        }
        // Get orders that belong to a customer
        /*
        [ResponseType(typeof(List<Order>))]
        public async Task<IHttpActionResult> GetCustomerOrders(int id)
        {
            Customer customer = await db.Customers.FindAsync(id);
            List<Order> allOrders = db.Orders.ToList();
            List<Order> customerOrders = [new Order()];

            for (int i = 0; i < allOrders.Count; i++)
            {
                if (allOrders.FindIndex(i).customerId == id)
                {
                    customerOrders.Add(allOrders[i]);
                }
            }           

            return OK(customerOrders);
        }
        */

        // Custom method
        private bool isCustomer(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return false;
            }
            return true;
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // implementing custom method
            if(!isCustomer(id, customer))
            {
                return BadRequest();
            }

            db.Entry(customer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Customers
        [ResponseType(typeof(Customer))]
        public async Task<IHttpActionResult> PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Customers.Add(customer);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = customer.CustomerId }, customer);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(Customer))]
        public async Task<IHttpActionResult> DeleteCustomer(int id)
        {
            Customer customer = await db.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            // Implementing custom method for delete to check if customer exists before deleting
            if(!isCustomer(id, customer))
            {
                return NotFound();
            }

            db.Customers.Remove(customer);
            await db.SaveChangesAsync();

            return Ok(customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerExists(int id)
        {
            return db.Customers.Count(e => e.CustomerId == id) > 0;
        }
    }
}