using geerirajwebapis.Model;

namespace geerirajwebapis.Repositories.Interface
{
    public interface ICommanDropAsync
    {
        Task<List<ProductTypeModel>> GetProductTypeDrop();
    }
}
