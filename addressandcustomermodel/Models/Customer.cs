using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace addressandcustomermodel.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public Address ShippingAddress { get; set; }
        public Address BillingAddress { get; set; }

    }
}