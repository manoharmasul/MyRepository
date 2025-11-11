namespace geerirajwebapis.Model
{
    public class EnquiryMailModel
    {
        public int Id { get; set; }
        public string? Subject { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNo { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyType { get; set; }
        public int? Qty { get; set; }
        public string? Message { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? Mark { get; set; }
        public bool? IsRead { get; set; }

    }
    public class EnquiryModel
    {
        public string? CompanyType { get; set; }
        public string? Title { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Company { get; set; }
        public string? Phone { get; set; }
        public string? Message { get; set; }
    }
}
