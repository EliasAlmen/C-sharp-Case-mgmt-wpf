using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC05_C_sharp_Case_mgmt_wpf.MVVM.Models.Entities
{
    public class CaseStatusEntity
    {
        [Key]
        public int CaseStatusId { get; set; }
        public string Status { get; set; } = "Open";


        public int CaseEntityId { get; set; }
        public CaseEntity CaseEntity { get; set; } = null!;
    }
}
