using EqualRights.Models;
using EqualRights.Service;
using EqualRights.Service.Interface;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EqualRights.ViewModels
{
    public class DetailsPageViewModel : ViewModelBase
    {
        private IData _data;
        private DelegateCommand _submitCommand;
        public DelegateCommand SubmitCommand =>
            _submitCommand ?? (_submitCommand = new DelegateCommand(ExecuteSubmitCommand));

        private User _userInfo;
        public User UserInfo
        {
            get { return _userInfo; }
            set { SetProperty(ref _userInfo, value); }
        }

        private async void ExecuteSubmitCommand()
        {
            var conn = new CoparentingDatabase();
            await conn.SaveItemAsync(UserInfo);
            await NavigationService.NavigateAsync("MasterD/NavigationPage/GalleryPage", useModalNavigation: true);
        }

        public DetailsPageViewModel(INavigationService navigationService, IData data) : base(navigationService)
        {
            var newUser = new User();
            UserInfo = newUser;

        }
}
    
}
