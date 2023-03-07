using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EC05_C_sharp_Case_mgmt_wpf.Contexts;
using EC05_C_sharp_Case_mgmt_wpf.MVVM.Models;
using EC05_C_sharp_Case_mgmt_wpf.MVVM.Models.Entities;
using EC05_C_sharp_Case_mgmt_wpf.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EC05_C_sharp_Case_mgmt_wpf.MVVM.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly DataContext _DataContext;

        public MainViewModel(DataContext dataContext)
        {
            _DataContext = dataContext;
            LoadCases();
        }

        #region ADD CASE
        [ObservableProperty]
        private string firstName = string.Empty;
        [ObservableProperty]
        private string tb_firstName = "First name";

        [ObservableProperty]
        private string lastName = string.Empty;
        [ObservableProperty]
        private string tb_lastName = "Last name";

        [ObservableProperty]
        private string email = string.Empty;
        [ObservableProperty]
        private string tb_email = "Email";

        [ObservableProperty]
        private string phoneNumber = string.Empty;
        [ObservableProperty]
        private string tb_phoneNumber = "Phone number";

        [ObservableProperty]
        private string description = string.Empty;
        [ObservableProperty]
        private string tb_description = "Case description";
        [ObservableProperty]
        private string tb_Description_text = "Max 500 characters";

        [RelayCommand]
        private async void AddCase()
        {
            if (
                FirstName == string.Empty ||
                LastName == string.Empty ||
                Email == string.Empty ||
                PhoneNumber == string.Empty ||
                Description == string.Empty
                )
            {
                MessageBox.Show("Please fill in all text fields.");
            }
            else
            {
                var caseModel = new CaseModel();

                caseModel.FirstName = FirstName;
                caseModel.LastName = LastName;
                caseModel.Email = Email;
                caseModel.PhoneNumber = PhoneNumber;
                caseModel.Description = Description;

                //save customer to database
                await CaseService.SaveAsync(caseModel);


                // Clear fields after contact was added.
                FirstName = string.Empty;
                LastName = string.Empty;
                Email = string.Empty;
                PhoneNumber = string.Empty;
                Description = "Max 500 characters";


                // Confirmation MessageBox
                //MessageBox.Show($"{FirstName}\n{LastName}\n\nAdded.");
                LoadCases();

            }
        }
        #endregion


        /// <summary>
        /// Observable property with INotifyChanged created by source generators
        /// </summary>
        [ObservableProperty]
        public ObservableCollection<CustomerEntity> cases = new();

        /// <summary>
        /// Loads existing ToDos from the DataContext
        /// </summary>
        private void LoadCases()
        {
            Cases.Clear();
            var todos = _DataContext!.Customers.Where(o => !o.IsDone).ToList();
            todos.ForEach(o =>
            {
                Cases.Add(o);
            });
        }

        

    }
}
