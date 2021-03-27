using InventoryManagement.Models.Entities;
using InventoryManagement.Models.Entities._DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models.Services_BL.Users
{
    public interface IUserService
    {
        List<UserData> GetUsers();
        UserData GetUserById(int Id);
        UserData AddUser(UserSubmissionModel model);
        bool DeleteUser(int userId);
        bool UpdateUser(UserUpdateSubmissionModel userData);
    }
}
