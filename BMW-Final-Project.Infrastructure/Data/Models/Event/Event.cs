using BMW_Final_Project.Infrastructure.Data.IdentityModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BMW_Final_Project.Infrastructure.ValidationAttributes;
using static BMW_Final_Project.Infrastructure.Constants.DataConstants.EventConstants;

namespace BMW_Final_Project.Infrastructure.Data.Models.Event
{
    [Comment("Cloth table")]
    public class Event
    {
        [Key]
        [Comment("Event identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxEventNameLength)]
        [Comment("Name of the event")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Comment("Description of the event")]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [IsBeforeToday]
        [Comment("Start date of the event")]
        public DateTime StartEvent { get; set; }

        [Required]
        [Comment("End date of the event")]
        [IsBeforeToday]
        public DateTime EndEvent { get; set; }
        
        [Required]
        [Comment("Place date of the event")]
        [MaxLength(PlaceMaxLength)]
        public string PlaceOfTheEvent { get; set; } = string.Empty;

        [Required]
        [Comment("Joiner identifier")]
        public Guid JoinerId { get; set; }

        [ForeignKey(nameof(JoinerId))]
        public ApplicationUser Joiner { get; set; } = null!;

        [Required]
        public bool IsActive { get; set; }

        [Required]
        [MaxLength(UrlMaxLength)]
        public string ImgUrl { get; set; } = string.Empty;

        public ICollection<EventJoiners> EventsJoiners { get; set; } = new List<EventJoiners>();

    }
}
