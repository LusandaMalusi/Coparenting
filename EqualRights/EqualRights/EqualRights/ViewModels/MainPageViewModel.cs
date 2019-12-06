using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EqualRights.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        private DelegateCommand _loginCommand;
        public DelegateCommand LoginCommand =>
            _loginCommand ?? (_loginCommand = new DelegateCommand(ExecuteLoginCommand));

        private DelegateCommand _SignCommand;
        public DelegateCommand SignCommand =>
            _SignCommand ?? (_SignCommand = new DelegateCommand(ExecuteSignCommand));

        private async void ExecuteLoginCommand()
        {
            await NavigationService.NavigateAsync("LoginPage");
        }


        public async void ExecuteSignCommand()
        {
            await NavigationService.NavigateAsync("CreateAccount");
        }
        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Main Page";
        }
    }
}