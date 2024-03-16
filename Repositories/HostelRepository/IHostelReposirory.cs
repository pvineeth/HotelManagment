using Models.DTOs.HostelDTOs;
using Models.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.HostelRepository
{
    public interface IHostelReposirory
    {
        Task<PaginationEntityDto<GetAllHostelDTO>> GetAllHostelsRepo(int skip,int maxResults);
        Task<GetAllHostelDTO> GetHostelByIdRepo(string hostelId);
        Task<List<GetAllHostelDTO>> GetAllHostelsNames();
        Task<Response> AddNewHostelRepo(AddNewHostelDTO hostelDetails);
        Task<Response> UpdateHostelRepo(GetAllHostelDTO hostelDetails);
        Task<Response> DeleteHostelRepo(string hostelId);
    }
}
