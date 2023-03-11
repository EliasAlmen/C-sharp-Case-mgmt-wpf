using CommunityToolkit.Mvvm.Input;
using EC05_C_sharp_Case_mgmt_wpf.MVVM.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace EC05_C_sharp_Case_mgmt_wpf.MVVM.Views
{
    /// <summary>
    /// Interaction logic for CaseDetailsWindow.xaml
    /// </summary>
    public partial class CaseDetailsWindow : Window
    {
        public CaseDetailsWindow()
        {

            InitializeComponent();
            this.DataContext = App.Current.Services.GetService<CaseDetailsViewModel>();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            e.Cancel = true;
        }

        //[RelayCommand]
        //private void UnlockDetailsView()
        //{
        //    tb_firstname.IsEnabled = true;
        //    tb_lastname.IsEnabled = true;
        //    tb_email.IsEnabled = true;
        //    tb_phonenumber.IsEnabled = true;
        //    tb_description.IsEnabled = true;
        //    tb_status.IsEnabled = true;
        //}
    }
}
