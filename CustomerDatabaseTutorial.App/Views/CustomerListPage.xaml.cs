using CustomerDatabaseTutorial.App.ViewModels;
using System.Linq;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using System;
using Windows.UI.Core;
using Microsoft.Toolkit.Uwp.Helpers;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CustomerDatabaseTutorial.App.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CustomerListPage : Page
    {
     public CustomerListPage()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }

        public CustomerListPageViewModel ViewModel { get; set; } =
            new CustomerListPageViewModel();
    }
}