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


        public User(int id,string username, string email, string password)  
        {
            this.Id = id;
            this.Username = username;
            this.Email = email;
            this.Password = password; // this.encrypt(password); 
            this.Role = "NoUser";
        }

        public User
            (int id, string username, string email, string password, string firstName, string lastName,string phoneNumber, string city)
        {
            this.Id = id;
            this.Username = username;
            this.Email = email;
            this.Password = password;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
            this.City = city;
            this.Role = "NoUser";
        }

        public int Id { get; set; }
        public string Username
        {
            get => username;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Username cannot be null ot empty");
                }
                username = value;
            }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string PhoneNumber 
        {
            get => phoneNumber;
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length != 10 && !value.All(char.IsDigit))
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

        public string Password
        {
            get => password;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Password cannot be null ot empty");
                }
                password = value;
            }
        }

      /*  public string encrypt(string password)
        {
            string md5_password = string.Empty;
            using (MD5 hash = MD5.Create())
            {
                md5_password = string.Join("", hash.ComputeHash(Encoding.UTF8.GetBytes(password)).Select(x => x.ToString("x2")));
            }

            return md5_password;
        }*/

        public string Role { get; set; }


    }
}
