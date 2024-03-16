namespace BMW_Final_Project.Engine.Models
{
    public class MotorcycleDetailsModel : MotorcycleModel
    {
        public string TypeMotor { get; set; } = string.Empty;

        public int Kg { get; set; }

        public int TankCapacity { get; set; }

        public int HorsePowers { get; set; }

        public int CC { get; set; }

        public string StandardEuro { get; set; } = string.Empty;

        public string Price { get; set; } = string.Empty;

        public string DTC { get; set; } = string.Empty;

        public string Transmission { get; set; } = string.Empty;

        public string FrontBreak { get; set; } = string.Empty;

        public string RearBreak { get; set; } = string.Empty;

        public int SeatHeightMm { get; set; }

        public int Amount { get; set; }

    }
}