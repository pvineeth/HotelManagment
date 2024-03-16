using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Hostel :AuditFields
    {
        [Key]
        public string PkhostelId { get; set; }
        public string HostelName { get; set; }
        [InverseProperty("Hostel")]
        public List<Branch> Branches { get; set;}
    }
}
