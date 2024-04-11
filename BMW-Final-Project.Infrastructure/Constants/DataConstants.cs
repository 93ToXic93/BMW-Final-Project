namespace BMW_Final_Project.Infrastructure.Constants
{
    public static class DataConstants
    {
        public static class EventConstants
        {
            public const int MaxEventNameLength = 50;
            public const int MinEventNameLength = 3;

            public const int DescriptionMaxLength = 500;
            public const int DescriptionMinLength = 10;

            public const int PlaceMaxLength = 100;
            public const int PlaceMinLength = 3;

            public const int UrlMaxLength = 60000;
            public const int UrlMinLength = 3;
        }

        public static class CategoryColorConstants
        {
            public const int MaxColorNameLength = 50;
            public const int MinColorNameLength = 3;
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

            public const double MinMotorcycleAmount = 1;
            public const double MaxMotorcycleAmount = 50000;
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

        public static class ApplicationUserConstants
        {
            public const int FirstNameMaxLength = 50;

            public const int LastNameMaxLength = 50;

            public const int NicknameMaxLength = 50;
        }

        public static class AccessorConstants
        {
            public const int MaxNameLength = 200;
            public const int MinNameLength = 3;

            public const int UrlMaxLength = 60000;
            public const int UrlMinLength = 3;

            public const double MaxPrice = 1000000;
            public const double MinPrice = 1;

            public const int MaxAmount = 1000000;
            public const int MinAmount = 1;

        }

        public static class ItemTypeConstants
        {
            public const int MaxNameLength = 200;
            public const int MinNameLength = 3;
        }

        public const string DataFormat = "dd/MM/yyyy";

        public const string DataFormatWithHours = "MM/dd/yyyy HH:mm";

        public const string DataFormatError =
            $"Правилният формат трябва да изглежда като: {DataFormat} и датата не трябва да е преди тази година!";

        public const string RequiredErrorMessage = "Полето {0} е задължително!";

        public const string LengthErrorMessage = "Полето {0} трябва да бъде между {2} и {1} символи!";

        public const string RangeErrorMessage = "Полето {0} трябва да бъде между {1} и {2}!";

        public const string UserMessageSuccess = "UserMessageSuccess";

        public const string UserMessageError = "UserMessageError";
    }
}