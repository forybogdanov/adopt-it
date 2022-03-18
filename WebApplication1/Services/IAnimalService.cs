using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    interface IAnimalService
    {
        void Edit(Animal animal);
        void Delete(int id);
        Animal GetById(int id);
        void Create(Animal animal);
    }
}
