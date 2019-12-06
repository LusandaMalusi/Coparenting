using EqualRights.Models;
using EqualRights.Service;
using EqualRights.Service.Interface;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EqualRights.ViewModels
{
    public class CreateAccountViewModel : ViewModelBase
    {
        private IData _data;
      
        private DelegateCommand _signUpCommand;
        public DelegateCommand SignUpCommand =>
            _signUpCommand ?? (_signUpCommand = new DelegateCommand(ExecuteSignUpCommand));

       
        private User _userInfo;
        public User UserInfo
        {
            get { return _userInfo; }
            set { SetProperty(ref _userInfo, value); }
        }

        private IPageDialogService _dialogService;


        public async void ExecuteSignUpCommand()
        {
            if (UserInfo.Name == null)
            {
                await _dialogService.DisplayAlertAsync("Alert", "Name is required!", "ok");
            }
            else if (UserInfo.Password == null)
            {
                await _dialogService.DisplayAlertAsync("Alert", "Password is required!", "ok");

            }
            else if (UserInfo.Surname == null)
            {
                await _dialogService.DisplayAlertAsync("Alert", "Surname is required!", "ok");
            }
            else if (UserInfo.Contacts == null)
            {
                await _dialogService.DisplayAlertAsync("Alert", "Phone number is required!", "ok");
            }
            else if (UserInfo.Email == null)
            {
                await _dialogService.DisplayAlertAsync("Alert", "Email address is required!", "ok");
            }
            else
            {
                var conn = new CoparentingDatabase();
                await conn.SaveItemAsync(UserInfo);
                //await App.Database.SaveItemAsync(userInfo);
                await NavigationService.NavigateAsync("LoginPage");
            }
        }

        public CreateAccountViewModel(INavigationService navigationService, IData data, IPageDialogService pageDialogService) : base(navigationService)
        {
            _data = data;
            var stuff = new User();
            UserInfo = stuff;

            _dialogService = pageDialogService;
        }


    }
}
