using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public interface IData
    {
        List<User> Users { get; set; }
    }
}