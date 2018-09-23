using System;
using Assignment2.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Assignment2.Services;
using Assignment2.ViewModels;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Assignment2
{
    public partial class App : Application
    {

        public static MainViewModel MainViewModel { get; set; }
        public static LoginViewModel LoginViewModel { get; set; }

        public App()
        {
            
            ILoginService login = new LoginService();
            NavigationService navi = new NavigationService();

            MainViewModel = new MainViewModel(navi);
            LoginViewModel = new LoginViewModel(login, navi);

            MyMainPage = new NavigationPage(new MainPage());
            LoginPage = new NavigationPage(new LoginPage());
            Page2 = new NavigationPage(new Page2());

            navi.Navi = MyMainPage.Navigation;
            navi.myPage = MyMainPage;
            InitializeComponent();
            MainPage = MyMainPage;
        }

        public static Page LoginPage { get; private set; }

        public static Page MyMainPage { get; private set; }

        public static Page Page2 { get; private set; }
    }
}
