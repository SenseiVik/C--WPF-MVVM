using CaeHolding.BLL.Interfaces;
using CarHolding.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaeHolding.BLL.Services
{
    class MsSqlServerService : IService<CarDTO>
    {
        public void CreateOrUpdate(CarDTO value)
        {
            throw new NotImplementedException();
        }

        public CarDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public CarDTO GetAt(int index)
        {
            throw new NotImplementedException();
        }

        public void Remove(CarDTO value)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
