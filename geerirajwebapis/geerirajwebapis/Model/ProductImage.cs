namespace geerirajwebapis.Model
{
    public class ProductImage
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string ImageName { get; set; }  

        public byte[] ImageData { get; set; }  

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; } = false;
    }
}
