using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EC05_C_sharp_Case_mgmt_wpf.Contexts;
using EC05_C_sharp_Case_mgmt_wpf.Migrations;
using EC05_C_sharp_Case_mgmt_wpf.MVVM.Models;
using EC05_C_sharp_Case_mgmt_wpf.MVVM.Models.Entities;
using EC05_C_sharp_Case_mgmt_wpf.MVVM.Views;
using EC05_C_sharp_Case_mgmt_wpf.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
            LoadOpenCases();
            //NewLoadOpenCases();
            LoadClosedCases();
            //ValueDone = IsDone ? "Open" : "Closed";
        }

        //todo: In case closed list add column for datetime -> closed.
        //todo: In case open list add column for pickuped / datetime pickuped

        #region Add case
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
        [ObservableProperty]
        private bool isDone;
        [ObservableProperty]
        private DateTime created;

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
                caseModel.IsDone = IsDone;

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
                LoadOpenCases();

            }
        }
        #endregion

        #region Load cases
        /// <summary>
        /// Observable property with INotifyChanged created by source generators
        /// </summary>
        [ObservableProperty]
        public ObservableCollection<CustomerEntity> cases = new();
        /// <summary>
        /// Loads existing Cases from the DataContext
        /// </summary>
        private void LoadOpenCases()
        {
            Cases.Clear();
            var _cases = _DataContext!.Customers.Where(o => !o.IsDone).Include(x => x.CommentEntity).ToList();
            _cases.ForEach(o =>
            {
                Cases.Add(o);
            });
        }
        /// <summary>
        /// Observable property with INotifyChanged created by source generators
        /// </summary>
        [ObservableProperty]
        public ObservableCollection<CustomerEntity> caseClose = new();
        private void LoadClosedCases()
        {
            CaseClose.Clear();
            var _cases = _DataContext!.Customers.Where(o => o.IsDone).ToList();
            _cases.ForEach(o =>
            {
                CaseClose.Add(o);
            });
        }
        #endregion

        #region Change status of case
        /// <summary>
        /// Updates the status with if-states 
        /// </summary>
        /// <param name="customer"></param>
        [RelayCommand]
        private void ChangeCaseStatus(CustomerEntity customer)
        {
            string messageBoxText = "Case completed?\n\n";
            string caption = $"Edit";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Question;
            MessageBoxResult result;
            result = MessageBox.Show(messageBoxText, caption, button, icon);

            switch (result)
            {
                case MessageBoxResult.Yes:
                        customer.IsDone = true;
                        _DataContext.SaveChanges();
                        LoadOpenCases();
                        LoadClosedCases();
                    break;
                case MessageBoxResult.No:
                        customer.IsDone = false;
                        _DataContext.SaveChanges();
                        LoadOpenCases();
                        LoadClosedCases();
                    break;
            }
        }
        #endregion

        #region Delete & update selected case
        [ObservableProperty]
        private CustomerEntity selectedCaseItem;
        [RelayCommand]
        private void DeleteSelected(CustomerEntity customer)
        {
            
            customer = SelectedCaseItem;
            string messageBoxText =
                "Delete case?\n\n" +
                $"{customer.FirstName}" + " " + $"{customer.LastName}\n" +
                $"{customer.Email}\n" +
                $"{customer.PhoneNumber}\n\n" +
                $"Case description:\n{customer.Description}\n\n" +
                $"Case status: {customer.IsDone}";
            string caption = $"Case Id {customer.Id}";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result;
            result = MessageBox.Show(messageBoxText, caption, button, icon);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    _DataContext.Customers.Remove(customer);
                    _DataContext.SaveChanges();
                    LoadOpenCases();
                    LoadClosedCases();
                    break;
                case MessageBoxResult.No:
                    // User pressed No
                    break;
            }
        }
        [RelayCommand]
        private void UpdateSelected(CustomerEntity customer)
        {
            string messageBoxText = "Update case?\n\n";
            string caption = $"Edit";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Question;
            MessageBoxResult result;
            result = MessageBox.Show(messageBoxText, caption, button, icon);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    customer = SelectedCaseItem;
                    _DataContext.Customers.Update(customer);
                    _DataContext.SaveChanges();
                    LoadOpenCases();
                    LoadClosedCases();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
        #endregion

        #region Lock & Unlock
        [ObservableProperty]
        private bool lock_firstname;
        [ObservableProperty]
        private bool lock_lastname;
        [ObservableProperty]
        private bool lock_email;
        [ObservableProperty]
        private bool lock_phonenumber;
        [ObservableProperty]
        private bool lock_description;
        [ObservableProperty]
        private string btn_unlock = "Unlock case";
        [ObservableProperty]
        private bool btn_enable_delete = false;
        [ObservableProperty]
        private bool btn_enable_update = false;
        [RelayCommand]
        private void UnlockSelected()
        {
            if (Lock_firstname == true)
            {
                Lock_firstname = false;
                Lock_lastname = false;
                Lock_email = false;
                Lock_phonenumber = false;
                Lock_description = false;
                Btn_unlock = "Unlock case";
                Btn_enable_delete = false;
                Btn_enable_update = false;
            }
            else
            {
                string messageBoxText = "Unlock case?\n\n";
                string caption = $"Edit";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, button, icon);

                switch (result)
                {
                    case MessageBoxResult.Yes:
                        Lock_firstname = true;
                        Lock_lastname = true;
                        Lock_email = true;
                        Lock_phonenumber = true;
                        Lock_description = true;
                        Btn_unlock = "Lock case";
                        Btn_enable_delete = true;
                        Btn_enable_update = true;
                        break;
                    case MessageBoxResult.No:
                        // User pressed No
                        break;
                }
            }
            

            
        }
        #endregion

        #region Save comment
        [ObservableProperty]
        private string commentTextInput = string.Empty;
        [ObservableProperty]
        private string commentAuthorInput = string.Empty;
        [ObservableProperty]
        private DateTime commentCreated;

        [ObservableProperty]
        private string commentText;
        [ObservableProperty]
        private string commentAuthor;
        [ObservableProperty]
        private int commentEntityId;

        [RelayCommand]
        private void CommentSave()
        {
            CommentEntity commentEntity = new()
            {
                CustomerEntityId = SelectedCaseItem.Id,
                CommentText = CommentTextInput,
                CommentAuthor = CommentAuthorInput,
            };
            _DataContext.Comments.Update(commentEntity);

            _DataContext!.SaveChanges();
            CommentTextInput = string.Empty;
            CommentAuthorInput = string.Empty;
            LoadOpenCases();
        }
        #endregion
    }
}
