using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.UserDTOs
{

    public class AddRoleDTO
    {
        public string RoleName { get; set; }
    }
    public class GetAllRolesDTO : AddRoleDTO
    {
        public string PkRoleId { get; set; }
    }
    
}
