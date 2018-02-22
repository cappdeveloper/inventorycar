using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using Challenger.Data.Entities;

namespace Challenger.Data
{
    public class ChallengerContext : DbContext
    {
        public ChallengerContext()
            : base("name=ChallengerConnection")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
         public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
      

    }
}
