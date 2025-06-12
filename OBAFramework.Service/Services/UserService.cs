using OBAFramework.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBAFramework.Service.Services
{
    public interface IUserService
    {
        UserDTO? ValidateCredentials(string username, string password);
        UserDTO? GetById(string userId);
    }
    public class UserService : IUserService
    {
        private readonly List<UserDTO> _users = new()
    {
        new UserDTO { Id = "1", Username = "admin", Password = "1234", Role = "Admin" },
        new UserDTO { Id = "2", Username = "user", Password = "12345", Role = "User" }
    };

        public UserDTO? ValidateCredentials(string username, string password)
        {
            return _users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public UserDTO? GetById(string userId)
        {
            return _users.FirstOrDefault(u => u.Id == userId);
        }
    }
}
