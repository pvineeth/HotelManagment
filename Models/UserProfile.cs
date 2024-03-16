using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UserProfile :AuditFields
    {
        [Key]
        public string PkUserProfileId { get; set; } 
        public string UserName { get; set; } 
        public string EmailID { get; set; } 
        public string Password { get; set; } 
        public string MobileNUmber { get; set; }

        [ForeignKey("FkRoleID")]
        public Role Role { get; set; }
        public string FkRoleID { get; set; }

        [InverseProperty("UserProfile")]
        public List<Branch> Branches { get; set; }
    }
}
