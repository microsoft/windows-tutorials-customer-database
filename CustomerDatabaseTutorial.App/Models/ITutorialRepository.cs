using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDatabaseTutorial.App.Models
{
    public interface ITutorialRepository
    {
        ICustomerRepository Customers { get; }
    }
}
