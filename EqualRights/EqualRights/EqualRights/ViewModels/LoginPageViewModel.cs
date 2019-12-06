using EqualRights.Models;
using EqualRights.Service.Interface;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Navigation.Xaml;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EqualRights.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private IData _data;

        private User _userInfo;
        public User UserInfo
        {
            get { return _userInfo; }
            set { SetProperty(ref _userInfo, value); }
        }

        private DelegateCommand _nextCommand;
        public DelegateCommand NextCommand =>
            _nextCommand ?? (_nextCommand = new DelegateCommand(ExecuteNextCommand));

        //private DelegateCommand _forgotPasswordCommand;
        //public DelegateCommand ForgotPasswordCommand =>
        //    _forgotPasswordCommand ?? (_forgotPasswordCommand = new DelegateCommand(ExecuteForgotPasswordCommand));


        //public async void ExecuteForgotPasswordCommand()
        // {
        //  await NavigationService.NavigateAsync("retrieve");
        //}


        public bool PasswExist { get; set; }
        public List<User> CustomerDetails { get; set; }

        private IPageDialogService _dialogService;
        public User Access { get; set; }



        public LoginPageViewModel(INavigationService navigationService, IData data, IPageDialogService pageDialogService) : base(navigationService)
        {
            _data = data;

            _dialogService = pageDialogService;
        }

        public override void Initialize(INavigationParameters parameters)
        {
          //  base.OnNavigatedFrom(parameters);

            UserInfo = new User();

        }


        private async void ExecuteNextCommand()
        {

            var knownUser = await _data.GetUserByUserName(UserInfo.Username);




            var Infor = UserInfo;

            if (knownUser is null)
                await _dialogService.DisplayAlertAsync("Alert", "Username unknown!", "ok");
            else
            if (Infor.Username == null)
            {
                await _dialogService.DisplayAlertAsync("Alert", "Username is required!", "ok");
            }
            else if (Infor.Password == null)
            {
                await _dialogService.DisplayAlertAsync("Alert", "Password is required!", "ok");
            }
            else
            {
                if (knownUser.Password == UserInfo.Password)
                {
                    PasswExist = true;
                    await NavigationService.NavigateAsync("DetailsPage");
                    return;
                }
                else
                    PasswExist = false;


                /* for (int i = 0; i < CustomerDetails.Count; i++)
                 {
                     if (CustomerDetails[i].Password == Infor.Password)
                     {
                         PasswExist = true;
                         await NavigationService.NavigateAsync("DetailsPage");
                         return;
                     }
                     else
                     {
                         PasswExist = false;
                     }*/
            }

            if (PasswExist == false)
            {
                await _dialogService.DisplayAlertAsync("Alert", "Incorrect Password Please try again", "ok");
            }
        }
    }
}

