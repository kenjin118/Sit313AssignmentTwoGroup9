using Assignment2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Assignment2.Services
{
    public interface IProductLoader
    {
        Task<List<Product>> LoadProducts();
    }
}
