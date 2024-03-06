using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Role :AuditFields
    {
        [Key]
        public string PkRoleId { get; set; }
        public string RoleName { get; set; }

        [InverseProperty("Role")]
        public List<UserProfile> UserProfiles { get; set; }  
    }
}
