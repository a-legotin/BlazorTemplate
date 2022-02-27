using BlazorTemplate.Api.Paging;
using BlazorTemplate.Classes.Models;
using BlazorTemplate.Classes.RequestFeatures;

namespace BlazorTemplate.Api.Repository
{
    public interface IProductRepository
    {
        Task<PagedList<Product>> GetProducts(ProductParameters productParameters);
        Task CreateProduct(Product product);
        Task<Product> GetProduct(Guid id);
        Task UpdateProduct(Product product, Product dbProduct);
        Task DeleteProduct(Product product);
    }
}
