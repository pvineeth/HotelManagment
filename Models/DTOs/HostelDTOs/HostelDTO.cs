using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.HostelDTOs
{
    public class HostelDTO
    {
    }

    public class GetAllHostelDTO
    {
        public string HostelName { get; set; }
        public string PkHostelId { get; set; }
    }
    public class AddNewHostelDTO
    {
        public string HostelName { get; set; }
    }

}
