using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjektZespolowy.Models;

namespace ProjektZespolowy
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions options) 
            :base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matchs { get; set; }
    }
}
