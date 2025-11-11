using System.ComponentModel.DataAnnotations;

namespace geerirajwebapis.Model
{
    public class Products
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public int ProductType { get; set; }

        public decimal ProductMrp { get; set; }

        public decimal ProductPrice { get; set; }

        public decimal Height { get; set; }   

        public decimal Width { get; set; }

        public decimal Diameter { get; set; }

        public string Brand { get; set; }

        public string Colour { get; set; }

        public string Material { get; set; }

        public string RecommendedUsesFor { get; set; }

        public string SpecialFeature { get; set; }

        public string DoorStyle { get; set; }

        public decimal WeightLimit { get; set; }

        public int CreatedBy { get; set; }

        public string ProductSummery { get; set; }

        public DateTime CreatedDate { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool IsDeleted { get; set; }
        public string FileName { get; set; }
       public string videoFileName { get; set; }

        public byte[] FileData { get; set; }
        public byte[] videoFileData { get; set; }
        public bool updatePdf { get; set; }
        public bool updateVideo { get; set; }
    }
    public class GetProducts
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public int ProductType { get; set; }

        public decimal ProductMrp { get; set; }

        public decimal ProductPrice { get; set; }

        public decimal Height { get; set; }

        public decimal Width { get; set; }

        public decimal Diameter { get; set; }

        public string Brand { get; set; }

        public string Colour { get; set; }

        public string Material { get; set; }

        public string RecommendedUsesFor { get; set; }

        public string SpecialFeature { get; set; }

        public string DoorStyle { get; set; }

        public decimal WeightLimit { get; set; }

        public int CreatedBy { get; set; }

        public string ProductSummery { get; set; }

        public DateTime CreatedDate { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool IsDeleted { get; set; }
        public string PdfFileName { get; set; }

        public byte[] PdfFileDate { get; set; }

        public string videoFileName { get; set; }

        public byte[] videoFileData { get; set; }
        public List<ProductImageModel> Productimages { get; set; }
    }
    public class ProductImageModel
    {
        public string ImageName { get; set; }
        public byte[] ImageData { get; set; }
    }
}
