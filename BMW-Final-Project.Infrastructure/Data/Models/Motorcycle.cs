using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMW_Final_Project.Infrastructure.Data.Models
{
    public class Motorcycle
    {
        public int Id { get; set; }

        public string Model { get; set; } = string.Empty;

        public ColorCategory ColorCategory { get; set; } = null!;

    }
}
