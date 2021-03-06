﻿using GalaSoft.MvvmLight.Command;
using Assignment2.Async;
using Assignment2.Models;
using Assignment2.Services;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
namespace Assignment2.ViewModels
{
    public class CategoriesListViewModel : BaseViewModel
    {
        private readonly INavigationService _navi;
        private readonly RelayCommand _searchCommand;
        private readonly IProductService _service;

        public CategoriesListViewModel(IProductService service, INavigationService navi)
        {
            _service = service;
            _navi = navi;
            Items = new NotifyTaskCompletion<List<Product>>(_service.GetProducts());
            Categories = new NotifyTaskCompletion<List<string>>(_service.GetCategories());

            NavigateToCategory = new RelayCommand<string>(async cat =>
            {
                var items = (await _service.GetProductsForCategory(cat))
                    .OrderByDescending(i => i.Rating)
                    .ToList();

                if (items != null && items.Any())
                {
                    var page = App.GetProductsListPage(items, cat);
                    await _navi.PushAsync(page);
                }
                else
                {
                    await _navi.DisplayAlert("Error", "There are no items in the category " + cat);
                }
            });

            _searchCommand = new RelayCommand(Search, () => !string.IsNullOrWhiteSpace(SearchTerm));
        }

        public NotifyTaskCompletion<List<string>> Categories { get; private set; }

        public NotifyTaskCompletion<List<Product>> Items { get; private set; }

        public ICommand NavigateToCategory { get; private set; }

        public ICommand SearchCommand { get { return _searchCommand; } }

        public string SearchTerm
        {
            get { return GetValue<string>(); }
            set
            {
                SetValue(value);
                _searchCommand.RaiseCanExecuteChanged();
            }
        }

        private async void Search()
        {
            var items = (await _service.Search(SearchTerm))
                        .OrderByDescending(i => i.Rating)
                        .ToList();

            if (items != null && items.Any())
            {
                Page page = items.Count == 1
                     ? page = App.GetProductPage(items.First())
                     : page = App.GetProductsListPage(items, SearchTerm);

                await _navi.PushAsync(page);
                SearchTerm = string.Empty;
            }
            else
            {
                await _navi.DisplayAlert("Error", "No results for : " + SearchTerm);
            }
        }
    }
}
