using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EC05_C_sharp_Case_mgmt_wpf.Contexts;
using EC05_C_sharp_Case_mgmt_wpf.MVVM.Models.Entities;
using EC05_C_sharp_Case_mgmt_wpf.MVVM.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EC05_C_sharp_Case_mgmt_wpf.MVVM.ViewModels
{
    public partial class CaseDetailsViewModel : ObservableObject
    {
        //private readonly DataContext _DataContext;
        //private readonly CaseDetailsWindow _CaseDetailsWindow;

        public CaseDetailsViewModel()
        {
            //this._CaseDetailsWindow = App.Current.Services.GetService<CaseDetailsWindow>()!;
            //_DataContext = dataContext;

            //LoadOpenCases();
        }

        //[ObservableProperty]
        //private string firstName = string.Empty;

        //[ObservableProperty]
        //private string lastName = string.Empty;

        //[ObservableProperty]
        //private string email = string.Empty;

        //[ObservableProperty]
        //private string phoneNumber = string.Empty;

        //[ObservableProperty]
        //private string description = string.Empty;
        //[ObservableProperty]
        //private bool isDone;
        //[ObservableProperty]
        //private DateTime created;

        //[ObservableProperty]
        //public ObservableCollection<CustomerEntity> caseDetails = new();

        ///// <summary>
        ///// Loads existing ToDos from the DataContext
        ///// </summary>
        //private void LoadOpenCases()
        //{
        //    CaseDetails.Clear();
        //    var _casesDetail = _DataContext!.Customers.Where(o => !o.IsDone).ToList();
        //    _casesDetail.ForEach(o => { CaseDetails.Add(o); });
        //}


        
    }
}
