using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC05_C_sharp_Case_mgmt_wpf.MVVM.Models.Entities
{
    public class CommentEntity
    {
        [Key]
        public int CommentId { get; set; }
        [StringLength(75)]
        public string CommentAuthor { get; set; } = string.Empty;
        public string CommentText { get; set; } = string.Empty;
        public DateTime CommentCreated { get; set; } = DateTime.Now;

        public int CaseEntityId { get; set; }
        public CaseEntity CaseEntity { get; set; } = null!;
    }
}
