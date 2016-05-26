using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripSystem.Models
{
    public class Trip
    {
        public Trip()
        {
            this.Destinations = new HashSet<Destination>();
            this.Products = new HashSet<Product>();
            this.Notes = new HashSet<Note>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public virtual ICollection<Destination> Destinations { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<Note> Notes { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }

}
