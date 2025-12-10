namespace GrandLineAuto.Common
{
    public class EntityValidation
    {
        public static class Brand
        {
            public const byte BrandNameMinLength = 3;
            public const byte BrandNameMaxLength = 50;
        }

        public static class BrandModelsSeries
        {
            public const byte BrandModelsSeriesNameMinLength = 3;
            public const byte BrandModelsSeriesNameMaxLength = 50;
        }

        public static class BrandModels
        {
            public const byte BrandModelsNameMinLength = 3;
            public const byte BrandModelsNameMaxLength = 50;
        }

        public static class Category
        {
            public const byte CategoryNameMinLength = 3;
            public const byte CategoryNameMaxLength = 50;
        }

        public static class SubCategory
        {
            public const byte SubCategoryNameMinLength = 3;
            public const byte SubCategoryNameMaxLength = 50;
        }

        public static class Product
        {
            public const byte ProductNameMinLength = 3;
            public const byte ProductNameMaxLength = 100;

            public const byte DescriptionMinLength = 3;
            public const int DescriptionMaxLength = 650;
        }

        public static class ProductManufacturer
        {
            public const byte ProductManufacturerNameMinLength = 3;
            public const byte ProductManufacturerNameMaxLength = 50;
        }
    }
    
}
