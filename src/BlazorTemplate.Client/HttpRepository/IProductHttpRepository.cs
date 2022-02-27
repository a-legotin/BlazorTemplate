using BlazorProducts.Client.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorTemplate.Classes.Models;
using BlazorTemplate.Classes.RequestFeatures;

namespace BlazorProducts.Client.HttpRepository
{
    public interface IProductHttpRepository
    {
        Task<PagingResponse<Product>> GetProducts(ProductParameters productParameters);
        Task CreateProduct(Product product);
        Task<string> UploadProductImage(MultipartFormDataContent content);
        Task<Product> GetProduct(string id);
        Task UpdateProduct(Product product);
        Task DeleteProduct(Guid id);
    }
}
