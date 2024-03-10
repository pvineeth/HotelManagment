using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.UserDTOs
{
    public class GetAllUserDTO
    {
        public string PkUserProfileId { get; set; }
        public string UserName { get; set; }
        public string EmailID { get; set; }
        public string Password { get; set; }
        public string MobileNUmber { get; set; }
        public string RoleName { get; set; }
        public string FkroleId { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class AddUserDTO 
    {
        public string UserName { get; set; }
        public string EmailID { get; set; }
        public string Password { get; set; }
        public string MobileNUmber { get; set; }
        public string FkRoleId { get; set; }
    }
}
