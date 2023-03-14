﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC05_C_sharp_Case_mgmt_wpf.MVVM.Models.Entities
{
    public class CaseEntity
    {
        [Key]
        public int CaseId { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.Now;
        public bool IsDone { get; set; }


        //public int CaseStatusEntityId { get; set; }
        public CaseStatusEntity CaseStatusEntity { get; set; } = null!;


        //public int OwnerEntityId { get; set; }
        public OwnerEntity OwnerEntity { get; set; } = null!;


        //public int CommentEntityId { get; set; }
        public ICollection<CommentEntity> CommentEntity { get; set; } = null!;
    }
}
