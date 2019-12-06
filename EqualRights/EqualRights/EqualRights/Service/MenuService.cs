using EqualRights.Enums;
using EqualRights.Messages;
using EqualRights.Models;
using EqualRights.Service.Interface;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EqualRights.Service
{
    public class MenuService : IMenuService
    {
        private IEventAggregator _eventAggregator;
        public IList<DetailsItem> _allMenuItems;
        public bool LoggedIn { get; set; }

        public MenuService(IEventAggregator eventAggregator)
        {
            CreateMenuItems();

            _eventAggregator = eventAggregator;
        }
        public IList<DetailsItem> GetAllowedAccessItems()
        {
            if (LoggedIn)
            {
                var accessItems = new List<DetailsItem>();

                foreach (var item in _allMenuItems)
                {
                    if (item.MenuType == MenuItemEnum.Secured || item.MenuType == MenuItemEnum.UnSecured || item.MenuType == MenuItemEnum.LogOut)
                    {
                        accessItems.Add(item);
                    }
                }
                return accessItems.OrderBy(x => x.MenuOrder).ToList();
            }
            else
            {
                var accessItems = new List<DetailsItem>();
                foreach (var item in _allMenuItems)
                {
                    if (item.MenuType == MenuItemEnum.UnSecured || item.MenuType == MenuItemEnum.Login)
                    {
                        accessItems.Add(item);
                    }
                }
                return accessItems.OrderBy(x => x.MenuOrder).ToList();
            }
        }
        public bool LogIn(string userName, string password)
        {
            LoggedIn = true;
            return true;
        }
        public void LogOut()
        {
            LoggedIn = false;
            _eventAggregator.GetEvent<LogOutMessage>().Publish();
        }
        private void CreateMenuItems()
        {
            _allMenuItems = new List<DetailsItem>();
            var menuItem = new DetailsItem();
            menuItem.Id = 1;
            menuItem.DetailsItemName = "Emergencies";
            menuItem.NavigationPath = "NavigationPage/MenuPage";
            menuItem.MenuType = MenuItemEnum.UnSecured;
            menuItem.MenuOrder = 1;
            menuItem.DetailsImageName = "PB.jpg";
            _allMenuItems.Add(menuItem);
            menuItem = new DetailsItem();
            menuItem.Id = 2;
            menuItem.DetailsItemName = "Logout";
            menuItem.NavigationPath = "";
            menuItem.MenuOrder = 99;
            menuItem.MenuType = MenuItemEnum.LogOut;
            menuItem.DetailsImageName = "logout.png";
            _allMenuItems.Add(menuItem);
            menuItem = new DetailsItem();
            menuItem.Id = 3;
            menuItem.DetailsItemName = "Self Difense Tips ";
            menuItem.NavigationPath = "NavigationPage/Coparenting";
            menuItem.MenuOrder = 3;
            menuItem.MenuType = MenuItemEnum.UnSecured;
            menuItem.DetailsImageName = "SD.png";
            _allMenuItems.Add(menuItem);
            menuItem = new DetailsItem();
            menuItem.Id = 4;
            menuItem.DetailsItemName = "Profile";
            menuItem.NavigationPath = "NavigationPage/Profile";
            menuItem.MenuOrder = 4;
            menuItem.MenuType = MenuItemEnum.UnSecured;
            menuItem.DetailsImageName = "P.png";
            _allMenuItems.Add(menuItem);
        }
    }
}
