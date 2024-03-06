using ApplicationContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.DTOs.LogInDTO;
using Models.DTOs.ResponsesDTOs;
using Models.Utility;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.AuthenticationRepository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly HotelManagmentContext _Context;
        private readonly IConfiguration _configuration;

        public AuthenticationRepository(HotelManagmentContext context, IConfiguration configuration)
        {
            _Context = context;
            _configuration = configuration;
        }

        public async Task<LoginResponse> Login(LoginDTO userDetails)
        {
            var IsExit = await _Context.UserProfiles.Include(x=>x.Role).Where(x => x.EmailID == userDetails.UserMail && x.Password == userDetails.Password && x.IsActive &&!x.IsDeleted).FirstOrDefaultAsync();
            if (IsExit != null)
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Role,IsExit.Role.RoleName),
                    new Claim(ClaimTypes.Name,IsExit.UserName),
                    new Claim(ClaimTypes.PrimarySid,IsExit.PkUserProfileId),
                };
                var symmetricSecurityKey = _configuration.GetSection("SecurityConfig")["symmetricSecurityKey"];
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(symmetricSecurityKey??""));
                var signature = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                       symmetricSecurityKey,
                       claims: claims,
                       signingCredentials: signature,
                       expires: DateTime.UtcNow.AddDays(1));
                var jwt = new JwtSecurityTokenHandler().WriteToken(token);
                return new LoginResponse { Token=jwt };
            }
            else
            {
                return new LoginResponse { ErrorMessage= "Invalid username or password. Please check your credentials and try again." };
            }

        }
    }
}
