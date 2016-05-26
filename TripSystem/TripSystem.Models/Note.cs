using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripSystem.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public int TripId { get; set; }

        [ForeignKey("TripId")]
        public virtual Trip Trip { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
