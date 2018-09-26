using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;
namespace Assignment2.Services
{
    public class NavigationService : INavigationService
    {
        public INavigation Navi { get; internal set; }
        public Page myPage { get; set; }
        public IReadOnlyList<Page> ModalStack { get; }
        public IReadOnlyList<Page> NavigationStack { get; }

        public Task<Page> PopAsync()
        {
            return Navi.PopAsync();
        }

        public void InsertPageBefore(Page before, Page after)
        {
            Navi.InsertPageBefore(before,after);
        }

        public Task<Page> PopAsync(bool b)
        {
            return Navi.PopAsync(b);
        }


        public Task<Page> PopModalAsync()
        {
            return Navi.PopModalAsync();
        }

        public Task<Page> PopModalAsync(bool b)
        {
            return Navi.PopModalAsync(b);
        }

        public Task PopToRootAsync()
        {
            return Navi.PopToRootAsync();
        }

        public Task PopToRootAsync(bool b)
        {
            return Navi.PopToRootAsync(b);
        }


        public Task PushAsync(Page page)
        {
            return Navi.PushAsync(page);
        }

        public Task PushAsync(Page page, bool b)
        {
            return Navi.PushAsync(page, b);
        }

        public Task PushModalAsync(Page page)
        {
            return Navi.PushModalAsync(page);
        }

        public Task PushModalAsync(Page page, bool b)
        {
            return Navi.PushModalAsync(page, b);
        }

        public void RemovePage(Page page)
        {
            Navi.RemovePage(page);
        }



       

        public Task<bool> DisplayAlert(string title, string message, string accept, string cancel = null)
        {
            return myPage.DisplayAlert(title, message, accept, cancel);
        }
    }
}
