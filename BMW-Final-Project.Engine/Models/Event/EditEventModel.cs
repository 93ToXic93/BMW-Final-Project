using BMW_Final_Project.Infrastructure.Constants;
using BMW_Final_Project.Infrastructure.ValidationAttributes;
using System.ComponentModel.DataAnnotations;
using static BMW_Final_Project.Infrastructure.Constants.DataConstants.EventConstants;


namespace BMW_Final_Project.Engine.Models.Event
{
    public class EditEventModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        [StringLength(MaxEventNameLength, MinimumLength = MinEventNameLength, ErrorMessage = DataConstants.LengthErrorMessage)]
        [Display(Name = "Име")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = DataConstants.LengthErrorMessage)]
        [Display(Name = "Описание")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        [IsBeforeToday]
        [Display(Name = "Дата и час на започване на събитието")]
        public DateTime StartEvent { get; set; }

        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        [IsBeforeToday]
        [Display(Name = "Дата и час на закриването на събитието")]
        public DateTime EndEvent { get; set; }

        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        [Display(Name = "Местоположение на събитието")]
        public string PlaceOfTheEvent { get; set; } = string.Empty;


        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        [StringLength(UrlMaxLength, MinimumLength = UrlMinLength, ErrorMessage = DataConstants.LengthErrorMessage)]
        [Display(Name = "URL-снимка на събитието")]
        public string ImgUrl { get; set; } = string.Empty;
    }
}
