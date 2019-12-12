using EqualRights.Messages;
using EqualRights.Models;
using EqualRights.Service.Interface;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace EqualRights.ViewModels
{
    public class MasterDViewModel : ViewModelBase
    {
        private IMenuService _menuService;
        private IEventAggregator _eventAggregator;
        private ObservableCollection<DetailsItem> _detailsItems;
        public ObservableCollection<DetailsItem> DetailsItems




        {
            get { return _detailsItems; }
            set { SetProperty(ref _detailsItems, value); }
        }

        private DelegateCommand<DetailsItem> _navigateCommand;
        public DelegateCommand<DetailsItem> NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand<DetailsItem>(ExecuteNavigateCommand));


        public async void ExecuteNavigateCommand(DetailsItem item)
        {
            {
                if (item.MenuType == EqualRights.Enums.MenuItemEnum.LogOut)
                    _menuService.LogOut();
                else
                    await NavigationService.NavigateAsync(item.NavigationPath);
            }
        }

        public IList<DetailsItem> detailsItemsProperty;

        public MasterDViewModel(INavigationService navigationService, IMenuService menuService, IEventAggregator eventAggregator) : base(navigationService)
        {
            _menuService = menuService;
            _eventAggregator = eventAggregator;

            DetailsItems = new ObservableCollection<DetailsItem>(_menuService.GetAllowedAccessItems());

            //_eventAggregator.GetEvent<LogInMessage>().Subscribe(LoginEvent);

            _eventAggregator.GetEvent<LogOutMessage>().Subscribe(LogOutEvent);
        }
        public void LoginEvent(UserProfile userProfile)
        {
            DetailsItems = new ObservableCollection<DetailsItem>(_menuService.GetAllowedAccessItems());
            NavigationService.NavigateAsync("NavigationPage/AboutApp");
        }
        public void LogOutEvent()
        {
            DetailsItems = new ObservableCollection<DetailsItem>(_menuService.GetAllowedAccessItems());
            NavigationService.NavigateAsync("NavigationPage/MainPage");
            //var userProfile = new UserProfile();

            //_eventAggregator.GetEvent<LogOutMessage>().Publish(userProfile);
        }
    }
}
