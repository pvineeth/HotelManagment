using Models.DTOs.UserDTOs;
using Models.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task<PaginationEntityDto<GetAllUserDTO>> GetAllUsersRepo(int skip, int maxResult);
        Task<GetAllUserDTO> GetByUserIdRepo(string userId);
        Task<Response> UpdateUserRepo(GetAllUserDTO userDetails);
        Task<Response> AddUserRepo(AddUserDTO userDetails);
        Task<Response> DeleteUserRepo(string userId);
    }
}
