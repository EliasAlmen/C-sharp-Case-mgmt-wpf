using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EC05_C_sharp_Case_mgmt_wpf.MVVM.Models;
using EC05_C_sharp_Case_mgmt_wpf.MVVM.Models.Entities;
using EC05_C_sharp_Case_mgmt_wpf.MVVM.ViewModels;
using EC05_C_sharp_Case_mgmt_wpf.MVVM.Views;
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
        private readonly CaseDetailsWindow _caseDetailsWindow;
        private readonly AddCaseCommentWindow _addCaseCommentWindow;

        public MainWindow(CaseDetailsWindow caseDetailsWindow, AddCaseCommentWindow addCaseComment)
        {
            InitializeComponent();
            // Get the MainViewModel
            this.DataContext = App.Current.Services.GetService<MainViewModel>();
            _caseDetailsWindow = caseDetailsWindow;
            _addCaseCommentWindow = addCaseComment;
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = (ListViewItem)sender;
            var caseItem = (CaseEntity)item.DataContext;

            _caseDetailsWindow.DataContext = caseItem;
            _caseDetailsWindow.Show();

            //string messageBoxText = 
            //    $"{caseItem.FirstName}" + " " + $"{caseItem.LastName}\n" +
            //    $"{caseItem.Email}\n" +
            //    $"{caseItem.PhoneNumber}\n\n" +
            //    $"Case description:\n{caseItem.Description}\n\n" +
            //    $"Case status: {caseItem.IsDone}";
            //string caption = $"Case Id {caseItem.Id}";
            //MessageBoxButton button = MessageBoxButton.OK;
            //MessageBoxImage icon = MessageBoxImage.Information;
            //MessageBoxResult result;
            //result = MessageBox.Show(messageBoxText, caption, button, icon);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //todo: Fix this..
            var item = (Button)sender;
            var caseItem = (MainViewModel)item.DataContext;
            _addCaseCommentWindow.DataContext = caseItem;
            _addCaseCommentWindow.Show();

            //var item = (ListViewItem)sender;
            //var caseItem = (CustomerEntity)item.DataContext;

            //_caseDetailsWindow.DataContext = caseItem;
            //_caseDetailsWindow.Show();
        }
    }
}
