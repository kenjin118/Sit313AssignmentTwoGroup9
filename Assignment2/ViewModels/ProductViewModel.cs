using Xamarin.Forms;
using Assignment2.Models;
using Assignment2.Services;
using Assignment2.Async;
namespace Assignment2.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        private readonly INavigationService _navi;

        public ProductViewModel(INavigationService navi, Product product)
        {
            _navi = navi;
            Product = product;
            IconSource = AsyncImageSource.FromUriAndResource(product.IconUrl, "Assignment2.Resources.placeholderImageSmall.png");
        }

        public NotifyTaskCompletion<ImageSource> IconSource { get; private set; }

        public Product Product
        {
            get { return GetValue<Product>(); }
            set { SetValue(value); }
        }
    }
}
