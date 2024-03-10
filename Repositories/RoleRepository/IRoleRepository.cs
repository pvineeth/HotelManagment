using Models.DTOs.UserDTOs;
using Models.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.RoleRepository
{
    public interface IRoleRepository
    {
        Task<PaginationEntityDto<GetAllRolesDTO>> GetAllRoles(int skip,int maxResult);
        Task<GetAllRolesDTO> GetByRoleId(string roleId);
        Task<Response>UpdateRole(GetAllRolesDTO roleDetails);
        Task<Response> AddRole(AddRoleDTO roleDetails);
        Task<Response> DeleteRole(string roleId);
        Task<List<GetAllRolesDTO>> GetALlRoleNames();
    }
}
