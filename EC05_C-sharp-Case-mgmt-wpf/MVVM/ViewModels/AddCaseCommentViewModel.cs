using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EC05_C_sharp_Case_mgmt_wpf.Contexts;
using EC05_C_sharp_Case_mgmt_wpf.MVVM.Models.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EC05_C_sharp_Case_mgmt_wpf.MVVM.ViewModels
{
    public partial class AddCaseCommentViewModel : ObservableObject
    {
        //private readonly DataContext? _DataContext;



        //[ObservableProperty]
        //private string? commentTextInput;
        //[ObservableProperty]
        //private string? commentAuthorInput;
        //[ObservableProperty]
        //private DateTime commentCreated;

        //[RelayCommand]
        //private void CommentSave(CommentEntity comment)
        //{
        //    #region Maybe for later
        //    //string messageBoxText = "Comment case?\n\n";
        //    //string caption = $"Edit";
        //    //MessageBoxButton button = MessageBoxButton.YesNo;
        //    //MessageBoxImage icon = MessageBoxImage.Question;
        //    //MessageBoxResult result;
        //    //result = MessageBox.Show(messageBoxText, caption, button, icon);
        //    //switch (result)
        //    //{
        //    //    case MessageBoxResult.Yes:
        //    //        break;
        //    //    case MessageBoxResult.No:
        //    //        break;
        //    //} 
        //    #endregion
        //    comment.CommentCreated = CommentCreated;
        //    comment.CommentAuthor = CommentAuthorInput!;
        //    comment.CommentText = CommentTextInput!;
        //    _DataContext!.Update(comment);
        //    _DataContext!.SaveChanges();
        //}
    }
}
