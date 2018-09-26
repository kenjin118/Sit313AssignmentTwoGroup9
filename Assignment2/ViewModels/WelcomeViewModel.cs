using Assignment2.MVVM;
using System.Windows.Input;
using Xamarin.Forms;
using Assignment2;

namespace Assignment2.ViewModels
{
    public class WelcomeViewModel
    {
        private readonly INavigation _navi;

        public WelcomeViewModel(INavigation navi)
        {
            _navi = navi;
        }

        public ICommand GoToLoginPageCommand
        {
            get { return new SimpleCommand(() => _navi.PushAsync(App.LoginPage)); }
        }
    }
}