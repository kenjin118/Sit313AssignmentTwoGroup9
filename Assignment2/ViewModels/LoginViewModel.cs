﻿using Assignment2.MVVM;
using Assignment2.Services;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Assignment2.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly ILoginService _loginService;
        private readonly INavigationService _navigationService;

        public LoginViewModel(ILoginService loginService, INavigationService navigationService)
        {
            _loginService = loginService;
            _navigationService = navigationService;
        }

        public ICommand LoginCommand { get { return new SimpleCommand(Login); } }

        public string Password
        {
            get { return GetValue<string>(); }
            set { SetValue<string>(value); }
        }

        public string Username
        {
            get { return GetValue<string>(); }
            set { SetValue<string>(value); }
        }

        private async void Login()
        {
            bool result = await _loginService.LoginAsync(Username, Password);

            if (result)
            {
                //await _navigationService.PopAsync();
                await _navigationService.PushAsync(App.CategoriesListPage);
            }
            else
            {
                await _navigationService.DisplayAlert("Error", "Invalid username or password", "ok");
            }
        }
    }
}