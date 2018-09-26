using Xamarin.Forms;
using Assignment2.Models;
using Assignment2.Services;
using Assignment2.Async;
namespace Assignment2.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        private const string _resource = "Assignment2.Resources.placeholderImageSmall.png";

        public ProductViewModel(Product product)
        {
            Product = product;
            IconSource = AsyncImageSource.FromUriAndResource(product.IconUrl, _resource);
        }

        public NotifyTaskCompletion<ImageSource> IconSource { get; private set; }

        public Product Product
        {
            get { return GetValue<Product>(); }
            set { SetValue(value); }
        }
    }

}
