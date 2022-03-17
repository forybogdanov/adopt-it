using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Data;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Services
{
    public class UserService : IUserService
    {
        private UserDbContext dbContext;



        public UserService(UserDbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        public void Update(int id, UserDTO userDTO)
        {
            User user = this.GetEntityById(id);

            user.PhoneNumber = userDTO.PhoneNumber;
            user.FirstName = userDTO.FirstName;
            user.LastName = userDTO.LastName;
            user.City = userDTO.City;

            dbContext.SaveChanges();
        }


        public void Delete(int id)
        {
            User user = this.GetEntityById(id);
            dbContext.Users.Remove(user);

            dbContext.SaveChanges();

        }


        
        public User GetEntityById(int id)
        {
            return dbContext.Users.FirstOrDefault(u => u.Id == id);

        }

        public UserDTO GetById(int id)
        {
            return this.toDTO(dbContext.Users.FirstOrDefault(u => u.Id == id));

        }

        private User toEntity(UserDTO userDTO)
        {
            return new User();
        }

        private UserDTO toDTO(User user)
        {
            return new UserDTO(
                user.Id, user.UserName, user.Email, user.PasswordHash,
                user.FirstName, user.LastName, user.PhoneNumber, user.City); 
        }


    }
}
