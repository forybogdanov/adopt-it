using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Services
{
    public interface IUserService
    {
        /*void Edit(int id , UserDTO user);*/

        int LoggedId { get; }
        User GetEntityById(int id);
        UserDTO GetById(int id);

        bool Create(UserDTO user);
        bool Login(UserDTO user);
        void Logout();
        void Update( string firstName, string lastName, string city, string phoneNumber);
        void Delete();
    }
}
