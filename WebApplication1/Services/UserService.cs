using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Data;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Services
{
    public class UserService :IUserService
    {
        private IData data;
        private int id = 0;
        public UserService(IData data)
        {
            this.data = data;
            Create(new UserDTO(0, "asd",  "asd@gmail.com","pass"));
            Create(new UserDTO(0, "asd2",  "asd@gmail.com", "pass"));
            Create(new UserDTO(0, "asd3",  "asd@gmail.com", "pass"));
        }

        public bool Login(UserDTO userDTO)
        {
            User user =data.Users.Find(u => u.Email == userDTO.Email && u.Password == userDTO.PlainPassword); //passwords????

            if (user == null)
            {
                return false;
            }
            return true;
        }

        public void Create(UserDTO userDTO)
        {
            User user = toEntity(userDTO); // ????????????password
            user.Id = ++id;
            data.Users.Add(user);
        }

        public List<UserDTO> GetAll()
        {
            return data.Users.Select(u=> toDTO(u)).ToList();
        }

        public void Edit(int id, UserDTO userDTO)
        {
            User user = this.GetEntityById(id);
            user.Username = userDTO.Username;
            user.PhoneNumber = userDTO.PhoneNumber;
            user.Email = userDTO.Email;

        }

        public void Delete(int id)
        {
            User user = this.GetEntityById(id);
            data.Users.Remove(user);

        }

      

        public User GetEntityById(int id)
        {
            return data.Users.FirstOrDefault(u => u.Id == id);

        }

        public UserDTO GetById(int id)
        {
            return this.toDTO(data.Users.FirstOrDefault(u => u.Id == id));

        }

        private User toEntity(UserDTO userDTO)
        {
            return new User(userDTO.Id,userDTO.Username, userDTO.Email, userDTO.PlainPassword); //??????????????? 
         }

        private UserDTO toDTO(User user)
        {
            return new UserDTO(0, user.Username, user.Email, user.Password); //???????????????
         }

   
    }
}
