using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.DTOs
{
    public class UserDTO
    {
        private string email;
        private string phoneNumber;
        private string plainPassword;

        public UserDTO()
        {

        }

        public UserDTO(int id, string username, string email,string password)
        {
            Id = id;
            Username = username;
            Email = email;
            this.PlainPassword = password;
        }
        public UserDTO(int id, string email, string password)
        {
            Id = id;
            Email = email;
            this.PlainPassword = password;
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                if (value.Length != 10 || !value.All(char.IsDigit))
                {
                    throw new ArgumentException("Phone number must be 10 digits and to contain only numbers!");
                }
                phoneNumber = value;
            }
        }

        public string Email
        {
            get => email;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Email cannot be null ot empty");
                }
                email = value;
            }
        }

        public string PlainPassword { get => plainPassword; set => plainPassword = value; }
    }
}
