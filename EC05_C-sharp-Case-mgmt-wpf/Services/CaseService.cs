using EC05_C_sharp_Case_mgmt_wpf.MVVM.Models.Entities;
using EC05_C_sharp_Case_mgmt_wpf.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC05_C_sharp_Case_mgmt_wpf.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EC05_C_sharp_Case_mgmt_wpf.Services
{
    internal static class CaseService
    {
        private static DataContext _context = new();

        #region Add case to db
        /// <summary>
        /// Add case!
        /// </summary>
        /// <param name="caseModel"></param>
        /// <returns></returns>
        public static async Task SaveAsync(CaseModel caseModel)
        {

            var caseEntity = new CaseEntity
            {
                Description = caseModel.Description,
                IsDone = caseModel.IsDone,
            };

            caseEntity.OwnerEntity = new OwnerEntity
            {
                FirstName = caseModel.FirstName,
                LastName = caseModel.LastName,
                Email = caseModel.Email,
                PhoneNumber = caseModel.PhoneNumber
            };

            caseEntity.CaseStatusEntity = new CaseStatusEntity
            {
                Status = caseModel.Status
            };

            _context.Add(caseEntity);
            await _context.SaveChangesAsync();
        }
        #endregion

        // Plan was to use the CaseService more, but I got instance conflict for tracking. Had no time to fix. 

        //#region Save case comment
        ///// <summary>
        ///// Save case comment
        ///// </summary>
        ///// <param name="commentEntity"></param>
        ///// <returns></returns>
        //public static async Task SaveComment(CommentEntity commentEntity)
        //{
        //    _context.CommentsSql.Update(commentEntity);

        //    await _context.SaveChangesAsync();
        //}
        //#endregion

        //#region Save case status
        ///// <summary>
        ///// Save case status
        ///// </summary>
        ///// <param name="caseStatusEntity"></param>
        ///// <returns></returns>
        //public static async Task SaveCaseStatus(CaseStatusEntity caseStatusEntity)
        //{
        //    _context.CaseStatusSql.Update(caseStatusEntity);

        //    await _context.SaveChangesAsync();
        //}
        //#endregion

        //#region Remove case
        ///// <summary>
        ///// Remove case
        ///// </summary>
        ///// <param name="caseStatusEntity"></param>
        ///// <returns></returns>
        //public static async Task RemoveCase(CaseEntity caseEntity)
        //{
        //    _context.CasesSql.Remove(caseEntity);
        //    await _context.SaveChangesAsync();
        //}
        //#endregion

        //#region Update case
        ///// <summary>
        ///// Update case
        ///// </summary>
        ///// <param name="caseStatusEntity"></param>
        ///// <returns></returns>
        //public static async Task UpdateCase(CaseEntity caseEntity)
        //{
        //    _context.CasesSql.Update(caseEntity);

        //    await _context.SaveChangesAsync();
        //}
        //#endregion

    }
}
