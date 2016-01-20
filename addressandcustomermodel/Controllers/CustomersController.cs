using addressandcustomermodel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace addressandcustomermodel.Controllers
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public Customer Get(int id)
        {
            
            return (from c in _context.Customers
                    .Include(c => c.BillingAddress)
                    .Include(c => c.ShippingAddress)
                    where c.Id == id
                    select c).FirstOrDefault()
                    ;
        }


        static IList<Customer> _customers = new List<Customer>()
        {
            new Customer()
            {
                Id = 0,
                Firstname = "First",
                LastName = "Last",
                ShippingAddress = new Address()
                {
                    Id = 0,
                    Street = "Street",
                    City = "City"
                },
                BillingAddress = new Address()
                {
                    Id = 0,
                    Street = "Street",
                    City = "City"
                }

            }


        };


        public IEnumerable<Customer> Get()
        {
            return _customers;
        }

        public IHttpActionResult Post(Customer customer)
        {
           
            _context.Customers.Add(customer);
            _context.SaveChanges();


            _customers.Add(customer);
            return Ok();

        }

        public IHttpActionResult Delete(int id)
        {
            
            var customer = _context.Customers.Find(id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return Ok();

        }
    }
}

