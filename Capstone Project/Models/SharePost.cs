using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone_Project.Models
{
    public class SharePost
    {
        [Key]
        public int Id { get; set; }
        public bool Anonymous { get; set; }
        public string Content { get; set; }

        [ForeignKey("Participant")]
        public int ParticipantId { get; set; }
        public Participant Participant { get; set; }
    }
}
