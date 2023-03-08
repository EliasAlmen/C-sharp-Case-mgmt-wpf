using CommunityToolkit.Mvvm.ComponentModel;
using EC05_C_sharp_Case_mgmt_wpf.Contexts;
using EC05_C_sharp_Case_mgmt_wpf.MVVM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC05_C_sharp_Case_mgmt_wpf.MVVM.ViewModels
{
    public partial class CaseDetailsViewModel : ObservableObject
    {
        private readonly DataContext _DataContext;

        public CaseDetailsViewModel(DataContext dataContext)
        {
            _DataContext = dataContext;
            LoadOpenCases();
        }

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
        public ObservableCollection<CustomerEntity> caseDetails = new();

        /// <summary>
        /// Loads existing ToDos from the DataContext
        /// </summary>
        private void LoadOpenCases()
        {
            CaseDetails.Clear();
            var _casesDetail = _DataContext!.Customers.Where(o => !o.IsDone).ToList();
            _casesDetail.ForEach(o => { CaseDetails.Add(o); });
        }
    }
}
