using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicContestMVC.Models;

namespace MusicContestMVC.Data
{
    public class MusicContestMVCContext : DbContext
    {
        public MusicContestMVCContext (DbContextOptions<MusicContestMVCContext> options)
            : base(options)
        {
        }

        public DbSet<MusicContestMVC.Models.Organizer> Organizer { get; set; }

        public DbSet<MusicContestMVC.Models.Judge> Judge { get; set; }

        public DbSet<MusicContestMVC.Models.Contestant> Contestant { get; set; }

        public DbSet<MusicContestMVC.Models.Competition> Competition { get; set; }
    }
}
