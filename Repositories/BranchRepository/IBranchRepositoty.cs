using Models.DTOs.BranchDTOs;
using Models.DTOs.HostelDTOs;
using Models.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.BranchRepository
{
    public interface IBranchRepositoty
    {
        Task<PaginationEntityDto<GetAllBranchDTO>> GetAllBranchsRepo(int skip, int maxResults);
        Task<GetAllBranchDTO> GetBranchByIdRepo(string branchId);
        Task<List<GetAllBranchDTO>> GetAllBranchsNames();
        Task<Response> AddNewBranchRepo(AddNewBranchDTO branchDetails);
        Task<Response> UpdateBranchRepo(UpdateBranchDTO branchDetails);
        Task<Response> DeleteBanchRepo(string branchId);
    }
}
