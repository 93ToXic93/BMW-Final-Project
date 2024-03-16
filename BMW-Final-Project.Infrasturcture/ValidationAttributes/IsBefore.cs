using System.ComponentModel.DataAnnotations;

namespace BMW_Final_Project.Infrastructure.ValidationAttributes
{
    public class IsBefore : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime date)
            {
                int currentYear = DateTime.Now.Year;
                int givenYear = date.Year;

                if (givenYear < currentYear)
                {
                    return new ValidationResult("The year should be this year or next year we are selling new motorcycles.");
                }
                else if (givenYear > currentYear + 1)
                {
                    return new ValidationResult("The year should be this year or next year we are selling new motorcycles.");
                }
            }

            return ValidationResult.Success;
        }

    }
}
