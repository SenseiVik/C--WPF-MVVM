using CaeHolding.BLL.Interfaces;
using CarHolding.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarHolding.DAL.Interfaces;
using CarHolding.DAL.Repositories;

namespace CaeHolding.BLL.Services
{
    public class MsSqlServerService : IService<CarDTO>
    {
        private IUnitOfWork unitOfWork;

        public MsSqlServerService()
        {
            unitOfWork = new EFUnitOfWork();
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
            return unitOfWork.Cars
                                .GetAll()
                                    .Select(x => new CarDTO(x.Id,
                                                            x.Title, 
                                                            x.Volume, 
                                                            x.Year, 
                                                            x.Price, 
                                                            x.Color, 
                                                            x.TransmissionType.TransmissionType1, 
                                                            x.DriveType.DriveType1, 
                                                            x.BodyType.BodyType1, 
                                                            x.ImagePath)).ToList();
            
        }

        public CarDTO GetAt(int index)
        {
            throw new NotImplementedException();
        }

        public void Remove(CarDTO value)
        {
            var tmp = unitOfWork.Cars.Get(value.Id);

            if (tmp != null)
            {
                unitOfWork.Cars.Remove(tmp);
            }
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }
    }
}
