using EqualRights.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EqualRights.Service.Interface
{
    public interface IMenuService
    {

        IList<DetailsItem> GetAllowedAccessItems();
        bool LogIn(string Username, string Password);
        void LogOut();
    }
}
