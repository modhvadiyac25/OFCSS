using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OFCSS.ViewModel;

namespace OFCSS.Models
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Admin> admins { get; set; }
        public DbSet<Merchant> merchants { get; set; }
        public DbSet<Farmer> farmers { get; set; }
        public DbSet<CropSale> cropSales { get; set; }
        public DbSet<MerchantRequirment> merchantRequirments { get; set; }
       
       
    }
}
