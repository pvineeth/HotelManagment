using ApplicationContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.LogInDTO;
using Models.DTOs.ResponsesDTOs;
using Repositories.AuthenticationRepository;

namespace HotelManagment.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationRepository _authRepo;

        public AuthenticationController(IAuthenticationRepository authRepo)
        {
            _authRepo = authRepo;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginDTO userDetails)
        {
            if (ModelState.IsValid)
            {
                var response=await _authRepo.Login(userDetails);
                if (response.Success)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
                
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
