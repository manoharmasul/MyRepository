using geerirajwebapis.Model;

namespace geerirajwebapis.Repositories.Interface
{
    public interface IProductAsyncRepository
    {
        Task<int> AddNewProducts(Products prod);
        Task<int> ProductsImages(ProductImage images);
        Task<int> UPdateProducts(Products prod);
        Task<List<Products>> GetAllProducts();
        Task<List<GetProducts>> GetAllProductsTypeId(int TypeId);
        Task<List<Products>> GetProductsByTypeId(int TypeId);
        Task<List<Products>> GetProductsbyName(string SearchTesx);
        Task<GetProducts> GetProductById(int Id);  
        Task<int> DeleteProduct(int Id);
        Task<int> DeleteProductimages(int productId);
    }
}
