
using Xamarin.Forms;
using System.Threading.Tasks;
namespace Assignment2.Services
{
    public class NavigationService : INavigation
    {
        public INavigation Navi { get; internal set; }
        public Page myPage { get; set; }

        public Task<Page> PopAsync()
        {
            return Navi.PopAsync();
        }

        public Task<Page> PopModalAsync()
        {
            return Navi.PopModalAsync();
        }

        public Task PopToRootAsync(bool b)
        {
            return Navi.PopToRootAsync();
        }

        public Task PushAsync(Page page)
        {
            return Navi.PushAsync(page);
        }

        public Task PushModalAsync(Page page)
        {
            return Navi.PushModalAsync(page);
        }

        public Task<bool> DisplayAlert(string title, string message, string accept, string cancel = null)
        {
            return myPage.DisplayAlert(title, message, accept, cancel);
        }
    }
}
