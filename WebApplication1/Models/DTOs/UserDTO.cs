using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.DTOs
{
    public class UserDTO
    {

        public UserDTO()
        {
        }

        public UserDTO
            (int id, string username, string email, string plainPassword, string firstName, string lastName, string phoneNumber, string city)
        {
            this.Id = id;
            this.Username = username;
            this.Email = email;
            this.PlainPassword = plainPassword;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
            this.City = city;
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }

        public string Email { get; set; }


        [Required(ErrorMessage = "Password is required.")]
        public string PlainPassword { get; set; }



    }
}
