using geerirajwebapis.Model;

namespace geerirajwebapis.Repositories.Interface
{
    public interface IEnquiryMailRepository
    {
        Task<int> AddEnquiryMail(EnquiryMailModel model);
        Task<int> ReadEnquiryMail(bool IsRead);
        Task<int> SaveEnquiryMail(bool IsSaved);
    }
}
