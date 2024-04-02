using BMW_Final_Project.Infrastructure.Data.IdentityModels;
using BMW_Final_Project.Infrastructure.Data.Models.Cloths;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BMW_Final_Project.Engine.Models.Cloth
{
    public class AllMineCloths
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ImgUrl { get; set; } = string.Empty;

        public string Price { get; set; } = string.Empty;

        public string Size { get; set; } = string.Empty;
        public Guid BuyerId { get; set; }

    }
}
