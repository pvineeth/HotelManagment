using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.HostelDTOs;
using Models.DTOs.UserDTOs;
using Models.Utility;
using Repositories.HostelRepository;

namespace HotelManagment.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostelController : ControllerBase
    {
        private readonly IHostelReposirory _hostelRepository;

        public HostelController(IHostelReposirory hostelRepository)
        {
            _hostelRepository = hostelRepository;
        }

        [HttpGet]
        [Route("GetAllHostels")]
        public async Task<ActionResult<PaginationEntityDto<GetAllHostelDTO>>> GetAllHostels(int skip, int maxResult)
        {
            var result = await _hostelRepository.GetAllHostelsRepo(skip, maxResult);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetHostelById")]
        public async Task<ActionResult<GetAllHostelDTO>> GetHostelById(string hostelId)
        {
            var result = await _hostelRepository.GetHostelByIdRepo(hostelId);
            return Ok(result);
        }
        [HttpPut]
        [Route("UpdateHostel")]
        public async Task<ActionResult<Response>> UpdateHostel(GetAllHostelDTO hostelDetails)
        {
            var result = await _hostelRepository.UpdateHostelRepo(hostelDetails);
            return Ok(result);
        }
        [HttpPost]
        [Route("AddNewHostel")]
        public async Task<ActionResult<Response>> AddNewHostel(AddNewHostelDTO hostelDetails)
        {
            var result = await _hostelRepository.AddNewHostelRepo(hostelDetails);
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteHostel")]
        public async Task<ActionResult<Response>> DeleteHostel(string hostelId)
        {
            var result = await _hostelRepository.DeleteHostelRepo(hostelId);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllHostelNames")]
        public async Task<ActionResult<List<GetAllRolesDTO>>> GetAllHostelNames()
        {
            var result = await _hostelRepository.GetAllHostelsNames();
            return Ok(result);
        }
    }
}
