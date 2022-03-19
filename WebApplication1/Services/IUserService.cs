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

        User GetEntityById(int id);
        UserDTO GetById(int id);
        void Update(int id, UserDTO userDTO);
        void Delete(int id);
    }
}
