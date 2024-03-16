using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.BranchDTOs
{
    public class BranchDTOs
    {
    }
    public class GetAllBranchDTO
    {
        public string PkbranchId { get; set; }
        public string BranchName { get; set; }
        public string UserName { get; set; }
        public string HostelName { get; set; }
    }
    public class AddNewBranchDTO
    {
        public string BranchName { get; set; }
        public string FKUserId { get; set; }
        public string FkHostelId { get; set; }
    }
    public class UpdateBranchDTO
    {
        public string PkbranchId { get; set; }
        public string BranchName { get; set; }
        public string FKUserId { get; set; }
        public string FkHostelId { get; set; }
    }
}
