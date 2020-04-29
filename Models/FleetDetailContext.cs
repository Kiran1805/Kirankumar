using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApiAssignment.Models
{
    public class FleetDetailContext : DbContext
    {
        public FleetDetailContext(DbContextOptions<FleetDetailContext> opt) : base(opt)
        {

        }
        public DbSet<FleetDetail> FleetDetails { get; set; }
    }
}
