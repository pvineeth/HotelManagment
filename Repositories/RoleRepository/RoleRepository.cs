using ApplicationContext;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTOs.UserDTOs;
using Models.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.RoleRepository
{
    public class RoleRepository : IRoleRepository
    {

        private readonly HotelManagmentContext _context;

        public RoleRepository(HotelManagmentContext context)
        {
            _context = context;
        }

        public async Task<Response> AddRole(AddRoleDTO roleDetails)
        {
            Role role = new Role();
            role.PkRoleId=Guid.NewGuid().ToString();
            role.RoleName=roleDetails.RoleName; 
            role.CreatedDate=DateTime.UtcNow;
            role.CreatedBy = "a";
            role.IsActive = true;
            role.IsDeleted = false;

            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
            return new Response();

        }

        public async Task<Response> DeleteRole(string roleId)
        {
            //var num = int.Parse(roleId);
           var role=await _context.Roles.FindAsync(roleId);
            if (role != null)
            {
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
                return new Response();
            }
            else
            {
                return new Response { ErrorMessage = "role Not Found" };
            }
        }

        public async Task<List<GetAllRolesDTO>> GetALlRoleNames()
        {
            return await _context.Roles.Select(x=>new GetAllRolesDTO { PkRoleId=x.PkRoleId,RoleName=x.RoleName }).ToListAsync();
        }

        public async Task<PaginationEntityDto<GetAllRolesDTO>> GetAllRoles(int skip, int maxResult)
        {
            var result = _context.Roles.Where(x => x.IsActive && !x.IsDeleted).Select(x => new GetAllRolesDTO
            {
                PkRoleId = x.PkRoleId,
                RoleName = x.RoleName,
            });

            var res = new PaginationEntityDto<GetAllRolesDTO>();
            res.Count = result.Count();
            res.Entities = result.ToList();
            return res;
         }

        public async Task<GetAllRolesDTO> GetByRoleId(string roleId)
        {
            var result =await _context.Roles.Where(x => x.IsActive && !x.IsDeleted&& x.PkRoleId== roleId).Select(x => new GetAllRolesDTO
            {
                PkRoleId = x.PkRoleId,
                RoleName = x.RoleName,
            }).FirstOrDefaultAsync();
            return result;
        }

        public async Task<Response> UpdateRole(GetAllRolesDTO roleDetails)
        {
            var role = await _context.Roles.Where(x=>x.PkRoleId==roleDetails.PkRoleId).FirstOrDefaultAsync();
            if (role != null)
            {
                role.RoleName = roleDetails.RoleName;
                role.ModifiedDate = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return new Response();
            }
            else
            {
                return new Response { ErrorMessage = "role Not Found" };
            }
        }
    }
}
