using BMW_Final_Project.Infrastructure.Data.IdentityModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_Final_Project.Infrastructure.Data.Models.Event
{
    [Comment("Events and joiners")]
    public class EventJoiners
    {
        [Required]
        [Comment("Event identifier")]
        public int EventId { get; set; }

        [ForeignKey(nameof(EventId))]
        public Event Event { get; set; } = null!;

        [Required]
        [Comment("Joiner identifier")]
        public Guid JoinerId { get; set; }

        [ForeignKey(nameof(JoinerId))]
        public ApplicationUser Joiner { get; set; } = null!;

    }
}
