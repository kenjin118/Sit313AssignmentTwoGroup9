using System.Threading.Tasks;

namespace Assignment2.Services
{
    public interface ILoginService
    {
        Task<bool> LoginAsync(string username, string password);
    }
}