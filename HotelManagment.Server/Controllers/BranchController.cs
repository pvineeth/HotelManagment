using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.BranchDTOs;
using Models.DTOs.HostelDTOs;
using Models.DTOs.UserDTOs;
using Models.Utility;
using Repositories.BranchRepository;
using Repositories.HostelRepository;

namespace HotelManagment.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchRepositoty _branchlRepository;

        public BranchController(IBranchRepositoty branchRepository)
        {
            _branchlRepository = branchRepository;
        }

        [HttpGet]
        [Route("GetAllBranchs")]
        public async Task<ActionResult<PaginationEntityDto<GetAllHostelDTO>>> GetAllBranchs(int skip, int maxResult)
        {
            var result = await _branchlRepository.GetAllBranchsRepo(skip, maxResult);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetBranchById")]
        public async Task<ActionResult<GetAllHostelDTO>> GetBranchById(string branchId)
        {
            var result = await _branchlRepository.GetBranchByIdRepo(branchId);
            return Ok(result);
        }
        [HttpPut]
        [Route("UpdateBranch")]
        public async Task<ActionResult<Response>> UpdateBranch(UpdateBranchDTO barnchDetails)
        {
            var result = await _branchlRepository.UpdateBranchRepo(barnchDetails);
            return Ok(result);
        }
        [HttpPost]
        [Route("AddNewBranch")]
        public async Task<ActionResult<Response>> AddNewBranch(AddNewBranchDTO branchDetails)
        {
            var result = await _branchlRepository.AddNewBranchRepo(branchDetails);
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteBranch")]
        public async Task<ActionResult<Response>> DeleteBranch(string branchId)
        {
            var result = await _branchlRepository.DeleteBanchRepo(branchId);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllBranchNames")]
        public async Task<ActionResult<List<GetAllRolesDTO>>> GetAllBranchNames()
        {
            var result = await _branchlRepository.GetAllBranchsNames();
            return Ok(result);
        }
    }
}
