using ApplicationContext;
using Microsoft.EntityFrameworkCore;
using Models;
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
    public class BranchRepository : IBranchRepositoty
    {
        private readonly HotelManagmentContext _context;

        public BranchRepository(HotelManagmentContext context)
        {
            _context = context;
        }

        public async Task<Response> AddNewBranchRepo(AddNewBranchDTO branchDetails)
        {
            Branch newBranch = new Branch();
            newBranch.PkbranchId = Guid.NewGuid().ToString();
            newBranch.BranchName = branchDetails.BranchName;
            newBranch.CreatedDate = DateTime.Now;
            newBranch.CreatedBy = "sai";
            newBranch.IsActive = true;
            newBranch.IsDeleted = false;
            newBranch.FkHostelId = branchDetails.FkHostelId;
            newBranch.FkUserId = branchDetails.FKUserId;
            await _context.Branches.AddAsync(newBranch);
            await _context.SaveChangesAsync();
            return new Response();
        }

        public async Task<Response> DeleteBanchRepo(string branchId)
        {
            var ExistingBranch = await _context.Branches.Where(x => x.PkbranchId == branchId && x.IsActive && !x.IsDeleted).FirstOrDefaultAsync();
            if (ExistingBranch != null)
            {
                _context.Branches.Remove(ExistingBranch);
                return new Response();
            }
            else
            {
                return new Response { ErrorMessage = "Branch Not Found." };
            }
        }

        public async Task<List<GetAllBranchDTO>> GetAllBranchsNames()
        {
            var result =await _context.Branches.Include(x => x.Hostel).Include(x => x.UserProfile).Where(x => x.IsActive && !x.IsDeleted).Select(x => new GetAllBranchDTO
            {
                PkbranchId = x.PkbranchId,
                BranchName = x.BranchName,
                HostelName = x.Hostel.HostelName,
                UserName = x.UserProfile.UserName
            }).ToListAsync();
            return result;
        }

        public async Task<PaginationEntityDto<GetAllBranchDTO>> GetAllBranchsRepo(int skip, int maxResults)
        {
            var result = _context.Branches.Include(x => x.Hostel).Include(x => x.UserProfile).Where(x => x.IsActive && !x.IsDeleted).Select(x => new GetAllBranchDTO
            {
                PkbranchId = x.PkbranchId,
                BranchName = x.BranchName,
                HostelName = x.Hostel.HostelName,
                UserName = x.UserProfile.UserName
            });
            var data = new PaginationEntityDto<GetAllBranchDTO>();
            data.Count = await result.CountAsync();
            data.Entities = await result.Skip(skip).Take(maxResults).ToListAsync();
            return data;
        }

        public async Task<GetAllBranchDTO> GetBranchByIdRepo(string branchId)
        {
            var result =await _context.Branches.Include(x => x.Hostel).Include(x => x.UserProfile).Where(x => x.IsActive && !x.IsDeleted && x.PkbranchId== branchId).Select(x => new GetAllBranchDTO
            {
                PkbranchId = x.PkbranchId,
                BranchName = x.BranchName,
                HostelName = x.Hostel.HostelName,
                UserName = x.UserProfile.UserName
            }).FirstOrDefaultAsync();
            return result;
        }

        public async Task<Response> UpdateBranchRepo(UpdateBranchDTO branchDetails)
        {
            var ExistingBranch = await _context.Branches.Where(x => x.PkbranchId == branchDetails.PkbranchId && x.IsActive && !x.IsDeleted).FirstOrDefaultAsync();
            if (ExistingBranch != null)
            {
                var IsNameAlreadyExists = await _context.Branches.Where(x => x.PkbranchId != branchDetails.PkbranchId && !x.IsDeleted && x.BranchName == branchDetails.BranchName).FirstOrDefaultAsync();
                if (IsNameAlreadyExists == null)
                {
                    ExistingBranch.BranchName = branchDetails.BranchName;
                    ExistingBranch.FkHostelId = branchDetails.FkHostelId;
                    ExistingBranch.FkUserId = branchDetails.FkHostelId;
                    await _context.SaveChangesAsync();
                    return new Response();
                }
                else
                {
                    return new Response { ErrorMessage = "Branch Already Exists." };
                }


            }
            else
            {
                return new Response { ErrorMessage = "Branch Not Found." };
            }
        }
    }
}
