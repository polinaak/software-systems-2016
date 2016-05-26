using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripSystem.Models
{
    public class User
    {
        public User()
        {
            this.Destinations = new HashSet<Destination>();
            this.Trips = new HashSet<Trip>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [MinLength(8)]
        [MaxLength(50)]
        public string Password { get; set; }

        public string SessionKey { get; set; }

        public virtual ICollection<Trip> Trips { get; set; }

        public virtual ICollection<Destination> Destinations { get; set; }
    }
}
