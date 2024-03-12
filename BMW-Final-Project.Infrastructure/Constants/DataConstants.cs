namespace BMW_Final_Project.Infrastructure.Constants
{
    public static class DataConstants
    {
        public static class CategoryConstants
        {
            public const int MaxColorNameLength = 50;
        }

        public static class StandardEuroConstants
        {
            public const int MaxStandardNameLength = 8;
            public const int MinStandardNameLength = 2;
        }

        public static class TypeMotorConstants
        {
            public const int MaxTypeNameLength = 50;
            public const int MinTypeNameLength = 3;
        }

        public static class MotorcycleConstants
        {
            public const int MaxMotorcycleModelLength = 200;
            public const int MinMotorcycleModelLength = 2;

            public const double MaxMotorcycleKg = 1000;
            public const double MinMotorcycleKg = 20;

            public const double MaxMotorcycleTankCapacity = 40;
            public const double MinMotorcycleTankCapacity = 2;

            public const double MaxMotorcycleHorsePowers = 1000;
            public const double MinMotorcycleHorsePowers = 2;

            public const double MaxMotorcycleCC = 2000;
            public const double MinMotorcycleCC = 40;

            public const double MaxMotorcyclePrice = 500000;
            public const double MinMotorcyclePrice = 200;

            public const int MaxMotorcycleDtcLengthLength = 500;
            public const int MinMotorcycleDtcLengthLength = 10;

            public const int MaxMotorcycleTransmissionLength = 500;
            public const int MinMotorcycleTransmissionLength = 10;

            public const int MaxMotorcycleFrontBrakeLength = 500;
            public const int MinMotorcycleFrontBrakeLength = 10;

            public const int MaxMotorcycleRearBrakeLength = 500;
            public const int MinMotorcycleRearBrakeLength = 10;

            public const int MaxMotorcycleImageUrlLength = 70000;
            public const int MinMotorcycleImageUrlLength = 2;

            public const double MaxMotorcycleSeatLength = 1500;
            public const double MinMotorcycleSeatLength = 20;
        }

        public static class ClothConstants
        {
            public const int NameMaxLength = 200;
            public const int NameMinLength = 10;

            public const int DescriptionMaxLength = 500;
            public const int DescriptionMinLength = 10;

            public const int ImgUrlMaxLength = 70000;
            public const int ImgUrlMinLength = 3;

            public const double PriceMax = 200000;
            public const double PriceMin = 1;

            public const double AmountMax = 200000;
            public const double AmountMin = 1;
        }
        public static class ClothCollectionConstants
        {
            public const int NameMaxLength = 100;
            public const int NameMinLength = 2;
        }
        public static class TypePersonConstants
        {
            public const int NameMaxLength = 40;
            public const int NameMinLength = 2;
        }
        public static class SizeConstants
        {
            public const int NameMaxLength = 15;
            public const int NameMinLength = 1;
        }

        public const string DataFormat = "dd/MM/yyyy";

    }
}
