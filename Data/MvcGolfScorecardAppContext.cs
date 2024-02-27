using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcGolfScorecardApp.Models;

namespace MvcGolfScorecardApp.Data
{
    public class MvcGolfScorecardAppContext : DbContext
    {
        public MvcGolfScorecardAppContext (DbContextOptions<MvcGolfScorecardAppContext> options)
            : base(options)
        {
        }

        public DbSet<MvcGolfScorecardApp.Models.Scorecard> Scorecard { get; set; } = default!;

        public DbSet<MvcGolfScorecardApp.Models.Course>? Course { get; set; }
    }
}
