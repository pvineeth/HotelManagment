using Models.DTOs.LogInDTO;
using Models.DTOs.ResponsesDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.AuthenticationRepository
{
    public interface IAuthenticationRepository
    {
        Task<LoginResponse> Login(LoginDTO userDetails);
    }
}
