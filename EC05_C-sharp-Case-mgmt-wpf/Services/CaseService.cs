﻿using EC05_C_sharp_Case_mgmt_wpf.MVVM.Models.Entities;
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
    internal class CaseService
    {
        private static DataContext _context = new();

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

            //var ownerEntity = new OwnerEntity
            //{
            //    FirstName = caseModel.FirstName,
            //    LastName = caseModel.LastName,
            //    Email = caseModel.Email,
            //    PhoneNumber = caseModel.PhoneNumber
                
            //};

            ////var caseEntity = new CaseEntity
            ////{
            ////    OwnerEntityId = ownerEntity.OwnerId,
            ////};

            ////ownerEntity.CaseEntity = new CaseEntity
            ////{

            ////};

            //var _caseEntity = await _context.CasesSql.FirstOrDefaultAsync(x => x.Description == caseModel.Description);
            //if (_caseEntity != null)
            //    ownerEntity.CaseEntityId = _caseEntity.CaseId;
            //else
            //    ownerEntity.CaseEntity = new CaseEntity
            //    {
            //        Description = caseModel.Description,
            //        IsDone = caseModel.IsDone
            //    };

            _context.Add(caseEntity);
            await _context.SaveChangesAsync();
        }

        //public static async Task<IEnumerable<CaseModel>> GetAllAsync()
        //{
        //    var _customers = new List<CaseModel>();
        //    foreach (var _customer in await _context.Customers.Include(x => x.Id).ToListAsync())
        //        _customers.Add(new CaseModel
        //        {
        //            Id = _customer.Id,
        //            FirstName = _customer.FirstName,
        //            LastName = _customer.LastName,
        //            Email = _customer.Email,
        //            PhoneNumber = _customer.PhoneNumber,
        //            Description = _customer.Description,
        //            Created = _customer.Created

        //        });
        //    return _customers;
        //}
    }
}
