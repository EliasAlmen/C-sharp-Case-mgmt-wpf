using EC05_C_sharp_Case_mgmt_wpf.MVVM.Models;
using EC05_C_sharp_Case_mgmt_wpf.MVVM.Models.Entities;
using EC05_C_sharp_Case_mgmt_wpf.MVVM.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EC05_C_sharp_Case_mgmt_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            // Get the MainViewModel
            this.DataContext = App.Current.Services.GetService<MainViewModel>();
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = (ListViewItem)sender;
            var caseItem = (CustomerEntity)item.DataContext;

            string messageBoxText = 
                $"{caseItem.FirstName}" + " " + $"{caseItem.LastName}\n" +
                $"{caseItem.Email}\n" +
                $"{caseItem.PhoneNumber}\n\n" +
                $"Case description:\n{caseItem.Description}\n\n" +
                $"Case status: {caseItem.IsDone}";
            string caption = $"Case Id {caseItem.Id}";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBoxResult result;

            result = MessageBox.Show(messageBoxText, caption, button, icon);
        }
    }
}
