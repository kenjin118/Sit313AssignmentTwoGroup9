using System;
using System.Collections.Generic;
using Assignment2.ViewModels;
using Xamarin.Forms;

namespace Assignment2.Views
{
    public partial class ProductsListPage : ContentPage
    {
        public ProductsListPage()
        {
            InitializeComponent();
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var param = e.SelectedItem as ProductViewModel;
            var command = ((ProductsListViewModel)BindingContext).NavigateToProduct;

            if (command.CanExecute(param))
            {
                command.Execute(param);
            }
        }
    }
}
