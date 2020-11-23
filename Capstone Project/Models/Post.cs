using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone_Project.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public bool Anonymous { get; set; }
        public string Content { get; set; }
        [ForeignKey("ParticipantId")]
        public string participantId { get; set; }
    }
}
