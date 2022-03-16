using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class AnimalService : IAnimalService
    {
        private IData data;
        private int id = 0;
        public void Create(Animal animal)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Animal animal)
        {
            throw new NotImplementedException();
        }

        public Animal GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
