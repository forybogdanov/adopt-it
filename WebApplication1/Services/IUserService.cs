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
        //List<UserDTO> GetAll();

        void Edit(int id , UserDTO user);
        void Delete(int id);
        UserDTO GetById(int id);
        void Create(UserDTO user);
        bool Login(UserDTO user);
    }
}
