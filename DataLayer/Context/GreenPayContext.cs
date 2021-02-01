using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class GreenPayContext:DbContext
    {
        public DbSet<PageGroup> PageGroups { get; set; }

        public DbSet<Page> Pages { get; set; }

        public DbSet<AdminLogin> AdminLogins { get; set; }

        public DbSet<Hamkaran> Hamkarans { get; set; }

        public DbSet<TeamMember> TeamMembers { get; set; }

        public DbSet<AboutDescription> AboutDescriptions { get; set; }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Activity> Activities { get; set; }

        public DbSet<Services> Services { get; set; }

    }
}
