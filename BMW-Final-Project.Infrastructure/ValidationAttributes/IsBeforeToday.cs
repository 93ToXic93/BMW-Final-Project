using System.ComponentModel.DataAnnotations;

namespace BMW_Final_Project.Infrastructure.ValidationAttributes
{
    public class IsBeforeToday : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime date)
            {
                var currentDate = DateTime.Now;
                var givenDate = date;

                if (givenDate < currentDate)
                {
                    return new ValidationResult("Датата на събитието не трябва да е минала!");
                }
            }

            return ValidationResult.Success;
        }
    }
}
