using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.UserDTOs;
using Models.Utility;
using Repositories.RoleRepository;
using Repositories.UserRepository;

namespace HotelManagment.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<ActionResult<PaginationEntityDto<GetAllUserDTO>>> GetAllUsers(int skip, int maxResult)
        {
            var result = await _userRepository.GetAllUsersRepo(skip, maxResult);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetuserById")]
        public async Task<ActionResult<GetAllUserDTO>> GetuserById(string userId)
        {
            var result = await _userRepository.GetByUserIdRepo(userId);
            return Ok(result);
        }
        [HttpPost]
        [Route("UpdateUser")]
        public async Task<ActionResult<Response>> UpdateUser(GetAllUserDTO userDetails)
        {
            var result = await _userRepository.UpdateUserRepo(userDetails);
            return Ok(result);
        }
        [HttpPost]
        [Route("AddUser")]
        public async Task<ActionResult<Response>> AddUser(AddUserDTO userDetails)
        {
            var result = await _userRepository.AddUserRepo(userDetails);
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<ActionResult<Response>> DeleteUser(string userId)
        {
            var result = await _userRepository.DeleteUserRepo(userId);
            return Ok(result);
        }
    }
}
