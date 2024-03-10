using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.UserDTOs;
using Models.Utility;
using Repositories.RoleRepository;

namespace HotelManagment.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet]
        [Route("GetAllRoles")]
        public async Task<ActionResult<PaginationEntityDto<GetAllRolesDTO>>> GetAllRoles(int skip,int maxResult)
        {
            var result = await _roleRepository.GetAllRoles(skip, maxResult);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetRoleById")]
        public async Task<ActionResult<GetAllRolesDTO>> GetRoleById(string roleId)
        {
            var result = await _roleRepository.GetByRoleId(roleId);
            return Ok(result);
        }
        [HttpPost]
        [Route("UpdateRole")]
        public async Task<ActionResult<Response>> UpdateRole(GetAllRolesDTO roleDetails)
        {
            var result = await _roleRepository.UpdateRole(roleDetails);
            return Ok(result);
        }
        [HttpPost]
        [Route("AddRole")]
        public async Task<ActionResult<Response>> AddRole(AddRoleDTO roleDetails)
        {
            var result = await _roleRepository.AddRole(roleDetails);
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteRole")]
        public async Task<ActionResult<Response>> DeleteRole(string roleId)
        {
            var result = await _roleRepository.DeleteRole(roleId);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllRoleName")]
        public async Task<ActionResult<List<GetAllRolesDTO>>> GetAllRoleName()
        {
            var result = await _roleRepository.GetALlRoleNames();
            return Ok(result);
        }
    }
}
