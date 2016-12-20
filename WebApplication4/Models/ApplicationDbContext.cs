using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication4.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Person> People { get; set; }        
        public DbSet<Claim> Claims { get; set; }
        public DbSet<Scan> Scans { get; set; }

        public DbSet<Building> Buildings { get; set; }

        public DbSet<State> ClaimStates { get; set; }
        public DbSet<RejectCause> RejectCauses { get; set; }
    }
}
