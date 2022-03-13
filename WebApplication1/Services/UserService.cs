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
        private int loggedId;
        public int LoggedId { get => findLoggedId();  }


        //private IData data;
        //private int id = -1;
        /* public UserService(IData data)
         {
             this.data = data;
             Create(new UserDTO(0, "asd", "as@gmail.com", "pass"));
             Create(new UserDTO(0, "asd2", "asd@gmail.com", "pass"));
             Create(new UserDTO(1, "asd3", "asf@gmail.com", "pass"));
         }*/

        public UserService(UserDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool Login(UserDTO userDTO)
        {
            User user = dbContext.Users.FirstOrDefault(u => u.Email == userDTO.Email && u.Password == userDTO.PlainPassword); //passwords????

            if (user == null)
            {
                return false;
            }
            user.Role = "User";
            dbContext.SaveChanges();

            loggedId = user.Id;
            return true;
        }

        public void Logout()
        {
            User user = GetEntityById(LoggedId);
            user.Role = "NoUser";
            dbContext.SaveChanges();
        }

        public bool Create(UserDTO userDTO)
        {
            if (dbContext.Users.FirstOrDefault(u  => u.Email == userDTO.Email) != null)
            {
                return false;
            }

            try
            {
                User user = toEntity(userDTO); // ????????????password

                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                return true;
            }
            catch (ArgumentException ex)
            {
                //throw new InvalidOperationException(ex.Message);
                return false;
            }
            
        }

       

        public void Update( string firstName, string lastName, string city, string phoneNumber)
        {
            User user = this.GetEntityById(LoggedId);
            user.PhoneNumber = phoneNumber;
            user.FirstName = firstName;
            user.LastName = lastName;
            user.City = city;

            dbContext.SaveChanges();
        }


        public void Delete()
        {
            User user = this.GetEntityById(LoggedId);
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
            return new User(
                    userDTO.Id, userDTO.Username, userDTO.Email, userDTO.PlainPassword,
                    userDTO.FirstName, userDTO.LastName, userDTO.PhoneNumber, userDTO.City); //??????????????? 
        }

        private UserDTO toDTO(User user)
        {
            return new UserDTO(
                user.Id, user.Username, user.Email, user.Password,
                user.FirstName, user.LastName, user.PhoneNumber, user.City,user.Role); //???????????????
        }

        private int findLoggedId()
        {
            User user = dbContext.Users.FirstOrDefault(u=> u.Role=="User");
            
            return user.Id;
        }
    }
}
