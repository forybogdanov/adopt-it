using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.DTOs
{
    public class UserDTO
    {
        private string username;
        private string email;
        private string phoneNumber;
        private string plainPassword;

        public UserDTO()
        {

        }

        public UserDTO(int id, string username, string email,string plainPassword)
        {
            Id = id;
            Username = username;
            Email = email;
            this.PlainPassword = plainPassword;
            this.Role = "NoUser";
        }
        public UserDTO(int id, string email, string plainPassword)
        {
            Id = id;
            Email = email;
            this.PlainPassword = plainPassword;
            this.Role = "NoUser";

        }

        public UserDTO
            (int id, string username, string email, string plainPassword, string firstName, string lastName,string phoneNumber, string city, string role)
        {
            this.Id = id;
            this.Username = username;
            this.Email = email;
            this.PlainPassword = plainPassword;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
            this.City = city;
            this.Role = role;
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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }

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

        public string PlainPassword 
        { 
            get => plainPassword; 
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Password cannot be null ot empty");
                }
                plainPassword = value;
            }
        }

        public string Role { get; set; }


    }
}
