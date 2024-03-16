using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Branch :AuditFields
    {
        [Key]
        public string PkbranchId { get; set; }
        public string BranchName { get; set; }

        [ForeignKey("FkHostelId")]
        public Hostel Hostel { get; set; }
        public string FkHostelId { get; set; }

        [ForeignKey("FkUserId")]
        public UserProfile UserProfile { get; set; }
        public string FkUserId { get; set; }


    }
}
