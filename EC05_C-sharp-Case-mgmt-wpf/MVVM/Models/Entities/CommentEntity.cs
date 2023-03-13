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
        public int CommentEntityId { get; set; }
        [StringLength(75)]
        public string CommentAuthor { get; set; } = string.Empty;
        [StringLength(200)]
        public string CommentText { get; set; } = string.Empty;
        public DateTime CommentCreated { get; set; } = DateTime.Now;

        public int CustomerEntityId { get; set; }
        public CustomerEntity CustomerEntity { get; set; } = null!;
    }
}
