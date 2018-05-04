using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CustomerDatabaseTutorial.App.Models;

namespace CustomerDatabaseTutorial.App.Repository
{
    public class SqlTutorialRepository : ITutorialRepository
    {

        private DbContextOptions<CustomerContext> _dbOptions;

        public SqlTutorialRepository(DbContextOptionsBuilder<CustomerContext> dbOptionsBuilder)
        {
            _dbOptions = dbOptionsBuilder.Options;
            using (var db = new CustomerContext(_dbOptions))
            {
                db.Database.EnsureCreated();
            }
        }

        public ICustomerRepository Customers => new SqlCustomerRepository(new CustomerContext(_dbOptions));
    }
}
