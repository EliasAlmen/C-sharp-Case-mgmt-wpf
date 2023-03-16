using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC05_C_sharp_Case_mgmt_wpf.MVVM.Models.Entities
{
    public class OwnerEntity
    {
        [Key]
        public int OwnerId { get; set; }
        [StringLength(75)]
        public string FirstName { get; set; } = string.Empty;
        [StringLength(75)]
        public string LastName { get; set; } = string.Empty;
        [StringLength(200)]
        public string Email { get; set; } = string.Empty;
        [StringLength(13)]
        public string PhoneNumber { get; set; } = string.Empty;

        public ICollection<CaseEntity> CaseEntity { get; set; } = null!;

    }
}
