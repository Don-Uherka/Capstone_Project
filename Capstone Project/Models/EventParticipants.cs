using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone_Project.Models
{
    public class EventParticipants
    {
        [Key]
        public int Id { get; set; }
        public bool Favorite { get; set; }
    
        public bool Founder { get; set; }

        [ForeignKey("Events")]
        public int EventId { get; set; }
        public Events Events { get; set; }

        [ForeignKey("Participant")]
        public int ParticipantId { get; set; }
        public Participant Participant { get; set; }
    }
}
