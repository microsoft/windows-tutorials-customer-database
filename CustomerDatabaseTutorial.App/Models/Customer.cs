using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDatabaseTutorial.App.Models
{
    public class Customer : IEquatable<Customer>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public Guid Id { get; set; } = Guid.NewGuid();
        public bool Equals(Customer otherCustomer)
        {
            return
                this.FirstName == otherCustomer.FirstName &&
                this.LastName == otherCustomer.LastName &&
                this.Company == otherCustomer.Company &&
                this.Email == otherCustomer.Email &&
                this.Phone == otherCustomer.Phone &&
                this.Address == otherCustomer.Address;
        }
    }
}
