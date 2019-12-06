using EqualRights.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EqualRights.Service.Interface
{
    public interface IData
    {
        Task<List<User>> GetItemsAsync();
        Task<List<User>> GetItemsNotDoneAsync();
        Task<User> GetItemAsync(int id);
        Task<int> SaveItemAsync(User item);
        Task<int> DeleteItemAsync(User item);
        Task<List<User>> GetUnSubmittedOrders();
        Task<User> GetUserByUserName(string userName);
    }
}
