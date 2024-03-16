using ApplicationContext;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTOs.HostelDTOs;
using Models.Utility;

namespace Repositories.HostelRepository
{
    public class HostelReposirory : IHostelReposirory
    {
        private readonly HotelManagmentContext _context;

        public HostelReposirory(HotelManagmentContext context)
        {
            _context = context;
        }

        public async Task<Response> AddNewHostelRepo(AddNewHostelDTO hostelDetails)
        {
            Hostel newhostel = new Hostel();
            newhostel.PkhostelId=Guid.NewGuid().ToString();
            newhostel.HostelName = hostelDetails.HostelName;
            newhostel.CreatedDate=DateTime.Now;
            newhostel.CreatedBy = "sai";
            newhostel.IsActive= true;
            newhostel.IsDeleted = false;
            await _context.Hostels.AddAsync(newhostel);
            await _context.SaveChangesAsync();
            return new Response();
        }

        public async Task<Response> DeleteHostelRepo(string hostelId)
        {
            var ExistingHostel=await _context.Hostels.Where(x=>x.PkhostelId==hostelId && x.IsActive && !x.IsDeleted).FirstOrDefaultAsync();
            if (ExistingHostel != null)
            {
                 _context.Hostels.Remove(ExistingHostel);
                await _context.SaveChangesAsync();
                return new Response();
            }
            else
            {
                return new Response { ErrorMessage = "Hostel Not Found." };
            }
        }

        public async Task<List<GetAllHostelDTO>> GetAllHostelsNames()
        {
            var result = await _context.Hostels.Where(x=>x.IsActive).Select(x => new GetAllHostelDTO
            {
                PkHostelId=x.PkhostelId,
                HostelName=x.HostelName
            }).ToListAsync();
            return result;
        }

        public async Task<PaginationEntityDto<GetAllHostelDTO>> GetAllHostelsRepo(int skip, int maxResults)
        {
            var result = _context.Hostels.Where(x => x.IsActive && !x.IsDeleted).Select(x => new GetAllHostelDTO
            {
                PkHostelId=x.PkhostelId,
                HostelName=x.HostelName
            });
            var data = new PaginationEntityDto<GetAllHostelDTO>();
            data.Count=await result.CountAsync();
            data.Entities = await result.Skip(skip).Take(maxResults).ToListAsync();
            return data;
        }

        public async Task<GetAllHostelDTO> GetHostelByIdRepo(string hostelId)
        {
            var result =await _context.Hostels.Where(x => x.IsActive && !x.IsDeleted && x.PkhostelId== hostelId).Select(x => new GetAllHostelDTO
            {
                PkHostelId = x.PkhostelId,
                HostelName = x.HostelName
            }).FirstOrDefaultAsync();
            return result;
        }

        public async Task<Response> UpdateHostelRepo(GetAllHostelDTO hostelDetails)
        {
            var ExistingHostel = await _context.Hostels.Where(x => x.PkhostelId == hostelDetails.PkHostelId && x.IsActive && !x.IsDeleted).FirstOrDefaultAsync();
            if (ExistingHostel != null)
            {
                var IsNameAlreadyExists=await _context.Hostels.Where(x=>x.PkhostelId!=hostelDetails.PkHostelId && !x.IsDeleted && x.HostelName==hostelDetails.HostelName).FirstOrDefaultAsync();
                if (IsNameAlreadyExists == null)
                {
                    ExistingHostel.HostelName=hostelDetails.HostelName;
                    await _context.SaveChangesAsync();
                    return new Response();
                }
                else
                {
                    return new Response { ErrorMessage = "hostel Already Exists." };
                }

               
            }
            else
            {
                return new Response { ErrorMessage = "Hostel Not Found." };
            }
        }
    }
}
