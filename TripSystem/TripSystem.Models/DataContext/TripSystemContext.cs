using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripSystem.Models.DataContext
{
    class TripSystemContext : DbContext
    {
        public TripSystemContext()
            : base("TripSystemDb")
        {

        }

        public DbSet<Trip> Trips { get; set; }

        public DbSet<Destination> Destinations { get; set; }

        public DbSet<Note> Notes { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
