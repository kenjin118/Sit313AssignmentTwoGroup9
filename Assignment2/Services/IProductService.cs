using Assignment2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Assignment2.Services
{
    public interface IProductService
    {
        Task<List<string>> GetCategories();

        Task<List<Product>> GetProducts();

        Task<List<Product>> GetProductsForCategory(string category);

        Task<List<Product>> Search(string searchString);
    }
}
