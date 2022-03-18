using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class User
    {
        private string username;
        private string email;
        private string phoneNumber;
        private string password;

        public User(int id, string username, string email, string password)
        {
            this.Id = id;
            this.Username = username;
            this.Email = email;
            this.Password = password; // this.encrypt(password); string method 
        }

        public int Id { get; set; }
        public string Username
        {
            get => username;
            set => username = value;
        }
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

        public string Password { get => password; set => password = value; }
    }
}