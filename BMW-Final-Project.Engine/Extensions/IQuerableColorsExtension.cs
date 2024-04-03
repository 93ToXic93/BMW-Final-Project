using BMW_Final_Project.Engine.Models.Motorcycle;
using BMW_Final_Project.Infrastructure.Data.Models.Motorcycle;

namespace BMW_Final_Project.Engine.Extensions
{
    public static class IQuerableColorsExtension
    {
        public static IQueryable<DeleteColorModel> ProjectToHouseServiceModel(this IQueryable<ColorCategory> color)
        {
            return color
                .Select(c => new DeleteColorModel()
                {
                    Id = c.Id,
                    IsActive = c.IsActive,
                    Name = c.Name
                });
        }
    }
}
