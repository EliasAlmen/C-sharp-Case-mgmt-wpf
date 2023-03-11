using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC05_C_sharp_Case_mgmt_wpf.MVVM.Models
{
    public class CommentModel
    {
        public int CommentId { get; set; }

        public string CommentAuthor { get; set; } = string.Empty;
        public string CommentText { get; set; } = string.Empty;
        public DateTime CommentCreated { get; set; } = DateTime.Now;
    }
}
