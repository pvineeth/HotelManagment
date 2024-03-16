using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationContext
{
    public class HotelManagmentContext: DbContext
    {
        public HotelManagmentContext(DbContextOptions<HotelManagmentContext>options):base(options) 
        { }

        public DbSet<Role>Roles { get; set; }
        public DbSet<UserProfile>UserProfiles { get; set; }
        public DbSet<Hostel>Hostels { get; set; }
        public DbSet<Branch>Branches { get; set; }
    }
}
