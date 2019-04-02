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

        public void CreateOrUpdate(CarDTO value, IEnumerable<CarDTO> collection = null)
        {
            this.logger.Save("data", collection);
        }

        public CarDTO Get(int id)
        {
            return logger.Load("data").FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<CarDTO> GetAll()
        {
            return logger.Load("data");
        }

        public CarDTO GetAt(int index)
        {
            return logger.Load("data").ToList()[index];
        }

        public void Remove(CarDTO value)
        {
            //var tmp = Get(value.Id);

            //if (tmp != null)
            //{
            //    var collection = logger.Load("data").ToList();
            //    collection.Remove(tmp);
            //    logger.Save("data", collection);
            //}
        }

        public void RemoveAt(int index)
        {
            var collection = logger.Load("data").ToList();
            collection.RemoveAt(index);
            logger.Save("data", collection);
        }

        public void Save(IEnumerable<CarDTO> value = null)
        {
            logger.Save("data", value);
        }
    }
}
