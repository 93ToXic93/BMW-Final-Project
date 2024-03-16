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
                    return new ValidationResult("Годината на производство трябва да е тази или следващата година! Продаваме нови мотори!");
                }
                else if (givenYear > currentYear + 1)
                {
                    return new ValidationResult("Годината на производство трябва да е тази или следващата година!");
                }
            }

            return ValidationResult.Success;
        }

    }
}