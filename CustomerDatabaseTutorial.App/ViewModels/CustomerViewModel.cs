using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Telerik.Core;
using CustomerDatabaseTutorial.App.Models;

namespace CustomerDatabaseTutorial.App.ViewModels
{
    public class CustomerViewModel
    {
        public CustomerViewModel(Customer model)
        {
            Model = model ?? new Customer();
        }

        /// <summary>
        /// The underlying customer model. Internal so it is 
        /// not visible to the RadDataGrid. 
        /// </summary>
        internal Customer Model { get; set; }

        /// <summary>
        /// Gets or sets whether the underlying model has been modified. 
        /// This is used when sync'ing with the server to reduce load
        /// and only upload the models that changed.
        /// </summary>
        internal bool IsModified { get; set; }

        /// <summary>
        /// Gets or sets the customer's first name.
        /// </summary>
        public string FirstName
        {
            get => Model.FirstName;
            set
            {
                if (value != Model.FirstName)
                {
                    Model.FirstName = value;
                    IsModified = true;
                }
            }
        }

        /// <summary>
        /// Gets or sets the customer's last name.
        /// </summary>
        public string LastName
        {
            get => Model.LastName;
            set
            {
                if (value != Model.LastName)
                {
                    Model.LastName = value;
                    IsModified = true;
                }
            }
        }

        /// <summary>
        /// Gets or sets the customer's address.
        /// </summary>
        public string Address
        {
            get => Model.Address;
            set
            {
                if (value != Model.Address)
                {
                    Model.Address = value;
                    IsModified = true;
                }
            }
        }

        /// <summary>
        /// Gets or sets the customer's company.
        /// </summary>
        public string Company
        {
            get => Model.Company;
            set
            {
                if (value != Model.Company)
                {
                    Model.Company = value;
                    IsModified = true;
                }
            }
        }
    }
}
