using ApplicationContext;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTOs.UserDTOs;
using Models.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly HotelManagmentContext _context;

        public UserRepository(HotelManagmentContext context)
        {
            _context = context;
        }

        public async Task<Response> AddUserRepo(AddUserDTO userDetails)
        {
            UserProfile user = new UserProfile();
            user.PkUserProfileId = Guid.NewGuid().ToString();
            user.UserName = userDetails.UserName;
            user.EmailID = userDetails.EmailID;
            user.Password = userDetails.Password;
            user.MobileNUmber = userDetails.MobileNUmber;
            user.FkRoleID = userDetails.FkRoleId;
            user.CreatedDate = DateTime.UtcNow;
            user.CreatedBy = "a";
            user.IsActive = true;
            user.IsDeleted = false;

            await _context.UserProfiles.AddAsync(user);
            await _context.SaveChangesAsync();
            return new Response();
        }

        public async Task<Response> DeleteUserRepo(string userId)
        {
            var user = await _context.UserProfiles.FindAsync(userId);
            if (user != null)
            {
                _context.UserProfiles.Remove(user);
                await _context.SaveChangesAsync();
                return new Response();
            }
            else
            {
                return new Response { ErrorMessage = "User Not Found" };
            }
        }

        public async Task<PaginationEntityDto<GetAllUserDTO>> GetAllUsersRepo(int skip, int maxResult)
        {
            var result = _context.UserProfiles.Include(x=>x.Role).Where(x => x.IsActive && !x.IsDeleted).Select(x => new GetAllUserDTO
            {
                PkUserProfileId = x.PkUserProfileId,
                UserName = x.UserName,
                EmailID = x.EmailID,
                Password = x.Password,
                MobileNUmber = x.MobileNUmber,
                RoleName=x.Role.RoleName,
                CreatedDate=x.CreatedDate,
            });

            var res = new PaginationEntityDto<GetAllUserDTO>();
            res.Count =await result.CountAsync();
            res.Entities =await result.OrderByDescending(x=>x.CreatedDate).ToListAsync();
            return res;
        }

        public async Task<GetAllUserDTO> GetByUserIdRepo(string userId)
        {
            var result = await _context.UserProfiles.Include(x=>x.Role).Where(x => x.IsActive && !x.IsDeleted && x.PkUserProfileId == userId).Select(x => new GetAllUserDTO
            {
                PkUserProfileId = x.PkUserProfileId,
                UserName = x.UserName,
                EmailID = x.EmailID,
                Password = x.Password,
                MobileNUmber = x.MobileNUmber,
                RoleName = x.Role.RoleName,
                CreatedDate = x.CreatedDate,
                FkroleId=x.Role.PkRoleId
            }).FirstOrDefaultAsync();
            return result?? new GetAllUserDTO();
        }

        public async Task<Response> UpdateUserRepo(GetAllUserDTO userDetails)
        {
            var user = await _context.UserProfiles.Where(x => x.PkUserProfileId == userDetails.PkUserProfileId).FirstOrDefaultAsync();
            if (user != null)
            {
                user.UserName = userDetails.UserName;
                user.EmailID = userDetails.EmailID;
                user.Password = userDetails.Password;
                user.MobileNUmber = userDetails.MobileNUmber;
                user.FkRoleID = userDetails.FkroleId;
                user.ModifiedDate = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return new Response();
            }
            else
            {
                return new Response { ErrorMessage = "User Not Found" };
            }
        }
    }
}
