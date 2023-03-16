using EC05_C_sharp_Case_mgmt_wpf.Contexts;
using EC05_C_sharp_Case_mgmt_wpf.Helpers;
using EC05_C_sharp_Case_mgmt_wpf.MVVM.Models;
using EC05_C_sharp_Case_mgmt_wpf.MVVM.ViewModels;
using EC05_C_sharp_Case_mgmt_wpf.MVVM.Views;
using EC05_C_sharp_Case_mgmt_wpf.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EC05_C_sharp_Case_mgmt_wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public App()
        {
            Services = ConfigureServices();
        }

        public new static App Current => (App)Application.Current;

        public IServiceProvider Services { get; }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // DataContext
            services.AddTransient<DataContext>();
            services.AddTransient<BooleanHelper>();
            services.AddTransient<CaseModel>();

            // ViewModels
            services.AddTransient<MainViewModel>();
            services.AddTransient<CaseDetailsViewModel>();
            services.AddTransient<AddCaseCommentViewModel>();

            //Views
            services.AddTransient<MainWindow>();
            services.AddTransient<CaseDetailsWindow>();
            services.AddTransient<AddCaseCommentWindow>();

            return services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var datacontext = Services.GetRequiredService<DataContext>();
            var mainWindow = Services.GetRequiredService<MainWindow>(); 
            mainWindow.DataContext = new MainViewModel(datacontext!);
            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}
