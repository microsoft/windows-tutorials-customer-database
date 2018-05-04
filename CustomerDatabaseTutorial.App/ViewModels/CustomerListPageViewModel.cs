using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp.Helpers;
using System.Runtime.CompilerServices;

namespace CustomerDatabaseTutorial.App.ViewModels
{
    public class CustomerListPageViewModel
    {
        public CustomerListPageViewModel()
        {
            Task.Run(GetCustomerListAsync);
        }

        private ObservableCollection<CustomerViewModel> _customers = new ObservableCollection<CustomerViewModel>();

        public ObservableCollection<CustomerViewModel> Customers { get => _customers; }


        private CustomerViewModel _selectedCustomer;

        public CustomerViewModel SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                if (_selectedCustomer != value)
                {
                    _selectedCustomer = value;
                }
            }
        }

        public async Task CreateNewCustomerAsync()
        {
            // Update this method
        }


        public async Task DeleteCustomerAsync()
        {
            // Update this method
        }

        public async void DeleteAndUpdateAsync()
        {
            // Update this method
        }

        public async Task GetCustomerListAsync()
        {
            // Update this method
        }

        public async Task SaveInitialChangesAsync()
        {
            // Update this method
        }

        public async Task UpdateCustomersAsync()
        {
            // Update this method
        }
    }
}
