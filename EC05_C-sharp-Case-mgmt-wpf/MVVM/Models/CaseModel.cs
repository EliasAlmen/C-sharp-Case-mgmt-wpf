using EC05_C_sharp_Case_mgmt_wpf.MVVM.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC05_C_sharp_Case_mgmt_wpf.MVVM.Models
{
    public class CaseModel
    {
        // Owner
        public int OwnerId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        //public CaseEntity CaseEntity { get; set; }


        // Case
        public int CaseId { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public bool IsDone { get; set; }

        // Case status
        public int CaseStatusId { get; set; }
        public string Status { get; set; } = string.Empty;


        // Comment
        public int CommentId { get; set; }
        public string CommentAuthor { get; set; } = string.Empty;
        public string CommentText { get; set; } = string.Empty;
        public DateTime CommentCreated { get; set; } = DateTime.Now;
    }
}
