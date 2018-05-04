using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerDatabaseTutorial.App.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerDatabaseTutorial.App.Repository
{
    public class SqlCustomerRepository : ICustomerRepository
    {
        private CustomerContext _db;

        public SqlCustomerRepository(CustomerContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Customer>> GetAsync()
        {
            return await _db.Customers
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Customer> GetAsync(Guid id)
        {
            return await _db.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Customer>> GetAsync(string value)
        {
            string[] parameters = value.Split(' ');
            return await _db.Customers
                .Where(x =>
                    parameters.Any(y =>
                        x.FirstName.StartsWith(y) ||
                        x.LastName.StartsWith(y) ||
                        x.Email.StartsWith(y) ||
                        x.Phone.StartsWith(y) ||
                        x.Address.StartsWith(y)))
                .OrderByDescending(x =>
                    parameters.Count(y =>
                        x.FirstName.StartsWith(y) ||
                        x.LastName.StartsWith(y) ||
                        x.Email.StartsWith(y) ||
                        x.Phone.StartsWith(y) ||
                        x.Address.StartsWith(y)))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Customer> UpsertAsync(Customer customer)
        {
            var current = await _db.Customers.FirstOrDefaultAsync(x => x.Id == customer.Id);
            if (null == current)
            {
                _db.Customers.Add(customer);
            }
            else
            {
                _db.Entry(current).CurrentValues.SetValues(customer);
            }
            await _db.SaveChangesAsync();
            return customer;
        }

        public async Task DeleteAsync(Guid id)
        {
            var customer = await _db.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (null != customer)
            {
                _db.Customers.Remove(customer);
                await _db.SaveChangesAsync();
            }
        }
    }
}
