using System;
using Xamarin.Forms;
using System.Threading.Tasks;
namespace Assignment2.Services
{
    public interface INavigationService : INavigation
    {
        Task<bool> DisplayAlert(string title, string message, string accept, string cancel = null);
    }
}
