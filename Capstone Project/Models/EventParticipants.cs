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

        [ForeignKey("EventId")]
        public int EventId { get; set; }

        [ForeignKey("ParticipantId")]
        public int ParticipantId { get; set; }
    }
}
