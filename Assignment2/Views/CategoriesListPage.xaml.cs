using Assignment2.ViewModels;
using Xamarin.Forms;

namespace Assignment2.Views
{
    public partial class CategoriesListPage : ContentPage
    {
        public CategoriesListPage()
        {
            InitializeComponent();
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var param = e.SelectedItem as string;
            var command = ((CategoriesListViewModel)BindingContext).NavigateToCategory;

            if (command.CanExecute(param))
            {
                command.Execute(param);
            }
        }
    }
}
