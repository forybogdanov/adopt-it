using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class UserData
    {

        public void Create(User user)
        {
            string sqlQuery = "INSERT INTO users(id, username,email) " +
                $"VALUES ({user.Id}, {user.Username}, {user.Email})";

            //connect to database
            //execute query
            //return state

            //hvurlqme exception ako ne stava 6toto e void
        }

    }
}
