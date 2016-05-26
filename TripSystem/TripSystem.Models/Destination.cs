using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripSystem.Models
{
    public class Destination
    {
        public Destination()
        {
            this.Trips = new HashSet<Trip>();
            this.Users = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }

        public virtual ICollection<Trip> Trips { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
