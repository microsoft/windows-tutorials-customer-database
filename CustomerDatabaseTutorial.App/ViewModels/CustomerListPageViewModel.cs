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
    public class CustomerListPageViewModel : INotifyPropertyChanged
    {
        public CustomerListPageViewModel()
        {
            Task.Run(GetCustomerListAsync);
        }

        private ObservableCollection<CustomerViewModel> _customers = new ObservableCollection<CustomerViewModel>();

        public ObservableCollection<CustomerViewModel> Customers { get => _customers; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
             PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private bool _addingNewCustomer = false;

        public bool AddingNewCustomer
        {
            get => _addingNewCustomer;
            set
            {
                if (_addingNewCustomer != value)
                {
                    _addingNewCustomer = value;
                    OnPropertyChanged();
                }
            }
        }

        private CustomerViewModel _selectedCustomer;

        public CustomerViewModel SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                if (_selectedCustomer != value)
                {
                    _selectedCustomer = value;
                    OnPropertyChanged();
                    AddingNewCustomer = false;
                }
            }
        }

        public async Task CreateNewCustomerAsync()
        {
            CustomerViewModel newCustomer = new CustomerViewModel(new Models.Customer());
            SelectedCustomer = newCustomer;
            await App.Repository.Customers.UpsertAsync(SelectedCustomer.Model);
            AddingNewCustomer = true;
        }


        public async Task DeleteCustomerAsync()
        {
            if (SelectedCustomer != null)
            {
                await App.Repository.Customers.DeleteAsync(_selectedCustomer.Model.Id);
                AddingNewCustomer = false;
            }
        }

        public async void DeleteAndUpdateAsync()
        {
            await DeleteCustomerAsync();
            await UpdateCustomersAsync();
        }

        public async Task GetCustomerListAsync()
        {
            var customers = await App.Repository.Customers.GetAsync();
            if (customers == null)
            {
                return;
            }
            await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                Customers.Clear();
                foreach (var c in customers)
                {
                    Customers.Add(new CustomerViewModel(c));
                }
            });
        }

        public async Task SaveInitialChangesAsync()
        {
            await App.Repository.Customers.UpsertAsync(SelectedCustomer.Model);
            await GetCustomerListAsync();
            AddingNewCustomer = false;
        }

        public async Task UpdateCustomersAsync()
        {
            foreach (var modifiedCustomer in Customers
                .Where(x => x.IsModified).Select(x => x.Model))
            {
                await App.Repository.Customers.UpsertAsync(modifiedCustomer);
            }
            await GetCustomerListAsync();
            AddingNewCustomer = false;
        }
    }
}
