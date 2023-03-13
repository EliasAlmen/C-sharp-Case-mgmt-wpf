﻿using EC05_C_sharp_Case_mgmt_wpf.MVVM.ViewModels;
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
    /// Interaction logic for AddCaseCommentWindow.xaml
    /// </summary>
    public partial class AddCaseCommentWindow : Window
    {
        public AddCaseCommentWindow()
        {
            InitializeComponent();
            //this.DataContext = App.Current.Services.GetService<AddCaseCommentViewModel>();

        }
        protected override void OnClosing(CancelEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            e.Cancel = true;
        }
    }
}
