using System;
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
            
            InitializeComponent();
            NavigationService navi = new NavigationService();

            MainViewModel = new MainViewModel(navi);

            MainPage = new NavigationPage(new MainPage());

            navi.Navi = MainPage.Navigation;
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
