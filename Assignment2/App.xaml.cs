using System;
using System.Collections.Generic;
using Assignment2.Models;
using Assignment2.ViewModels;
using Assignment2.Services;
using Assignment2.Views;
using Xamarin.Forms;
using System.Linq;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Assignment2
{
    public partial class App : Application
    {
        private static NavigationPage _firstPage;
        private static NavigationService NaviService;

        static App()
        {
            // Services
            ILoginService login = new LoginService();
            IProductLoader loader = new ProductLoader();
            IProductService products = new ProductService(loader);
            NaviService = new NavigationService();

            // View Models
            WelcomeViewModel = new WelcomeViewModel(NaviService);
            LoginViewModel = new LoginViewModel(login, NaviService);
            CategoriesListViewModel = new CategoriesListViewModel(products, NaviService);
            ProductsListViewModel = new ProductsListViewModel(NaviService);

            // Pages
            WelcomePage = new WelcomePage();
            LoginPage = new LoginPage();
            CategoriesListPage = new CategoriesListPage();

            // Startup Page
            FirstPage = WelcomePage;// CategoriesListPage;

            // Navi
            NaviService.Navi = FirstPage.Navigation;
            NaviService.myPage = FirstPage;
        }

        public static Page CategoriesListPage { get; set; }

        public static CategoriesListViewModel CategoriesListViewModel { get; set; }

        public static Page FirstPage
        {
            get { return _firstPage; }
            set { _firstPage = new NavigationPage(value); }
        }

        public static Page LoginPage { get; private set; }

        public static LoginViewModel LoginViewModel { get; set; }

        public static ProductsListViewModel ProductsListViewModel { get; set; }

        public static ProductViewModel ProductViewModel { get; set; }

        public static Page WelcomePage { get; private set; }

        public static WelcomeViewModel WelcomeViewModel { get; set; }

        public static Page GetProductPage(ProductViewModel productViewModel)
        {
            ProductViewModel = productViewModel;
            return new ProductPage();
        }

        public static Page GetProductsListPage(List<Product> products, string title)
        {
            if (string.IsNullOrWhiteSpace(title)) title = "Products";

            ProductsListViewModel.Products = products.Select(p => new ProductViewModel(NaviService, p)).ToList();
            ProductsListViewModel.Title = title;
            return new ProductsListPage();
        }
    }
}
