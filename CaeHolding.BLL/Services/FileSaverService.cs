using CarHolding.BLL.DTO;
using CarHolding.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHolding.BLL.Services
{
    public class FileSaverService : IService<CarDTO>
    {
        ILogger<IEnumerable<CarDTO>> logger;

        public FileSaverService(ILogger<IEnumerable<CarDTO>> logger)
        {
            this.logger = logger;
        }

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
            return logger.Load("data");
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

        public void Save(IEnumerable<CarDTO> value = null)
        {
            logger.Save("data", value);
        }
    }
}
