using InventoryManagement.Models.Contexts;
using InventoryManagement.Models.Entities;
using InventoryManagement.Models.Entities._DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models.Services_BL.Users
{
    public class UserService : IUserService
    {
        private readonly IAPI_DbContext _context;

        public UserService(IAPI_DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public UserData AddUser(UserSubmissionModel model)
        {
            var entity = model.ToEntity();
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;
            _context.Users.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool DeleteUser(int userId)
        {
            var entity = _context.Users.FirstOrDefault(x => x.Id == userId);
            if (entity != null)
            {
                _context.Users.Remove(entity);

                return _context.SaveChanges() > 0;
            }

            return false;
        }

        public UserData GetUserById(int Id)
        {
            var entity = _context.Users.Where(x => x.Id == Id).FirstOrDefault();

            return entity;
        }

        public List<UserData> GetUsers()
        {
            return _context.Users.ToList();
        }

        public bool UpdateUser(UserUpdateSubmissionModel userData)
        {
            var entity = _context.Users.FirstOrDefault(x => x.Id == userData.Id);
            if (entity != null)
            {
                entity.Id = userData.Id;
                entity.FullName = userData.FullName;
                entity.NrPhone = userData.NrPhone;
                entity.Email = userData.Email;
                entity.Password = userData.Password;
                entity.Address = userData.Address;

                return _context.SaveChanges() > 0;
            }

            return false;
        }
    }
}
