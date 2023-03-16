using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EC05_C_sharp_Case_mgmt_wpf.Contexts;
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
            LoadClosedCases();
        }
        #region ObservableProperties
        [ObservableProperty]
        private CaseEntity selectedCaseItem = null!;
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
        private DateTime created = DateTime.Now;
        [ObservableProperty]
        private string status = "Open";
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
        private string btn_unlock = "Unlock cases";
        [ObservableProperty]
        private bool btn_enable_delete = false;
        [ObservableProperty]
        private bool btn_enable_update = false;
        [ObservableProperty]
        private bool btn_enable_addComment = false;
        [ObservableProperty]
        private string commentTextInput = string.Empty;
        [ObservableProperty]
        private string commentAuthorInput = string.Empty;
        [ObservableProperty]
        private DateTime commentCreated;

        [ObservableProperty]
        private string commentText = string.Empty;
        [ObservableProperty]
        private string commentAuthor = string.Empty;
        [ObservableProperty]
        private int commentEntityId;
        #endregion
        #region Add case

        /// <summary>
        /// Checks fields and adds a case.
        /// </summary>
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
                caseModel.Created = Created;
                caseModel.Status = Status;

                //save customer to database
                await CaseService.SaveAsync(caseModel);


                // Clear fields after contact was added.
                FirstName = string.Empty;
                LastName = string.Empty;
                Email = string.Empty;
                PhoneNumber = string.Empty;
                Description = "Max 500 characters";


                // Confirmation MessageBox
                MessageBox.Show($"Case added.");
                LoadOpenCases();

            }
        }
        #endregion
        #region Load cases OPEN & CLOSED
        /// <summary>
        /// Observable property with INotifyChanged created by source generators
        /// </summary>
        [ObservableProperty]
        public ObservableCollection<CaseEntity> cases = new();
        /// <summary>
        /// Loads existing Cases from the DataContext that are NOT done. Also INCLUDES comments,owner,status.
        /// </summary>
        private void LoadOpenCases()
        {
            Cases.Clear();
            var _cases = _DataContext!.CasesSql.Where(o => !o.IsDone)
                .Include(x => x.CommentEntity)
                .Include(x => x.OwnerEntity)
                .Include(x => x.CaseStatusEntity)
                .ToList();
            _cases.ForEach(o =>
            {
                Cases.Add(o);
            });
        }
        /// <summary>
        /// Observable property with INotifyChanged created by source generators
        /// </summary>
        [ObservableProperty]
        public ObservableCollection<CaseEntity> caseClose = new();
        /// <summary>
        /// Loads existing Cases from the DataContext that are ARE closed. ONLY takes cases that are closed.
        /// </summary>
        private void LoadClosedCases()
        {
            CaseClose.Clear();
            var _cases = _DataContext!.CasesSql.Where(o => o.IsDone).ToList();
            _cases.ForEach(o =>
            {
                CaseClose.Add(o);
            });
        }
        #endregion
        #region Mark case as completed
        /// <summary>
        /// Updates the status with if-states. No solution for checkbox bug. 
        /// </summary>
        /// <param name="customer"></param>
        [RelayCommand]
        private void ChangeCaseStatus()
        {
            CaseEntity caseEntity = new();

            caseEntity = SelectedCaseItem;

            if (caseEntity == null)
            {
                string messageBoxTextNoItem = "No case selected..?\n\n" + "Please notice that the checkbox is now incorrect.";
                string captionNoItem = $"Edit";
                MessageBoxButton buttonNoItem = MessageBoxButton.OK;
                MessageBoxImage iconNoItem = MessageBoxImage.Error;
                MessageBoxResult resultNoItem;
                resultNoItem = MessageBox.Show(messageBoxTextNoItem, captionNoItem, buttonNoItem, iconNoItem);
            }
            else
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
                        caseEntity.IsDone = true;
                        caseEntity.CaseCompleted = DateTime.Now;
                        caseEntity.CaseStatusEntity = new CaseStatusEntity()
                        {
                            CaseEntityId = caseEntity.CaseId,
                            Status = "Closed"
                        };
                        _DataContext.CasesSql.Update(caseEntity);
                        _DataContext.SaveChanges();
                        LoadOpenCases();
                        LoadClosedCases();
                        break;
                    case MessageBoxResult.No:
                        caseEntity.IsDone = false;
                        _DataContext.CasesSql.Update(caseEntity);
                        _DataContext.SaveChanges();
                        LoadOpenCases();
                        LoadClosedCases();
                        break;
                }
            }
        }
        #endregion
        #region Delete & update selected case
        /// <summary>
        /// Deletes selected case in listview
        /// </summary>
        /// <param name="caseEntity"></param>
        [RelayCommand]
        private void DeleteSelected()
        {
            OwnerEntity ownerEntity = new()
            {
                OwnerId = SelectedCaseItem.CaseId

            };
            CaseEntity caseEntity = new();
            caseEntity = SelectedCaseItem;

            string messageBoxText =
                "Delete case?\n\n" +
                $"{ownerEntity.FirstName}" + " " + $"{ownerEntity.LastName}\n" +
                $"{ownerEntity.Email}\n" +
                $"{ownerEntity.PhoneNumber}\n\n" +
                $"Case description:\n{SelectedCaseItem.Description}\n\n" +
                $"Case status: {SelectedCaseItem.IsDone}";
            string caption = $"Case Id {SelectedCaseItem.CaseId}";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result;
            result = MessageBox.Show(messageBoxText, caption, button, icon);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    _DataContext.CasesSql.Remove(caseEntity);
                    _DataContext.SaveChanges();
                    LoadOpenCases();
                    LoadClosedCases();
                    break;
                case MessageBoxResult.No:
                    // User pressed No
                    break;
            }
        }
        /// <summary>
        /// Updates selected case in listview
        /// </summary>
        /// <param name="caseEntity"></param>
        [RelayCommand]
        private void UpdateSelected()
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
                    CaseEntity caseEntity = new();
                    caseEntity = SelectedCaseItem;
                    _DataContext.CasesSql.Update(caseEntity);
                    _DataContext.SaveChanges(); 
                    LoadOpenCases();
                    LoadClosedCases();
                    UnlockSelected();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
        #endregion
        #region Lock & Unlock
        /// <summary>
        /// Unlocks buttons to Change or delete case
        /// </summary>
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
                Btn_enable_addComment = false;
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
                        Btn_enable_addComment = true;
                        break;
                    case MessageBoxResult.No:
                        // User pressed No
                        break;
                }
            }
        }
        #endregion
        #region Pickup case
        /// <summary>
        /// Set selected listview item to ongoing-status.
        /// </summary>
        [RelayCommand]
        public void PickupCase()
        {
            if (SelectedCaseItem == null) 
            {
                MessageBox.Show("No case selected!");
            }
            else
            {
                if (SelectedCaseItem.CaseStatusEntity.Status == "Ongoing")
                {
                    MessageBox.Show("Case is already ongoing!");
                }
                CaseStatusEntity caseStatusEntity = new()
                {
                    CaseEntityId = SelectedCaseItem.CaseId,
                    Status = "Ongoing"
                };
                _DataContext.CaseStatusSql.Update(caseStatusEntity);
                _DataContext.SaveChanges();
                LoadOpenCases();
            }
        }
        #endregion
        #region Save comment
        /// <summary>
        /// Match selected listview item and add comment.
        /// </summary>
        [RelayCommand]
        private void CommentSave()
        {
            if (SelectedCaseItem == null)
            {
                string messageBoxTextNoItem = "No case selected..?\n\n";
                string captionNoItem = $"Edit";
                MessageBoxButton buttonNoItem = MessageBoxButton.OK;
                MessageBoxImage iconNoItem = MessageBoxImage.Error;
                MessageBoxResult resultNoItem;
                resultNoItem = MessageBox.Show(messageBoxTextNoItem, captionNoItem, buttonNoItem, iconNoItem);
            }
            else
            {
                CommentEntity commentEntity = new()
                {
                    CaseEntityId = SelectedCaseItem.CaseId,
                    CommentText = CommentTextInput,
                    CommentAuthor = CommentAuthorInput,
                };
                _DataContext.CommentsSql.Update(commentEntity);
                _DataContext.SaveChanges();
                CommentTextInput = string.Empty;
                CommentAuthorInput = string.Empty;
                LoadOpenCases();
            }
            
        }
        #endregion
    }
}
