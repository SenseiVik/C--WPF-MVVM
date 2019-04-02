using CarHolding.BLL.Interfaces;
using CarHolding.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarHolding.DAL.Interfaces;
using CarHolding.DAL.Repositories;

namespace CarHolding.BLL.Services
{
    public class MsSqlServerService : IService<CarDTO>
    {
        private IUnitOfWork unitOfWork;

        public MsSqlServerService()
        {
            unitOfWork = new EFUnitOfWork();
        }

        public void CreateOrUpdate(CarDTO value, IEnumerable<CarDTO> collection = null)
        {
            unitOfWork.Cars.CreateOrUpdate(new CarHolding.DAL.Car()
            {
                Id = value.Id,
                Title = value.Title,
                Color = value.Color,
                Price = value.Price,
                ImagePath = value.Image,
                Volume = value.Volume,
                Year = value.Year,
                DriveTypeId = (int)value.Drive,
                TransmissionTypeId = (int)value.Transmission,
                BodyTypeId = (int)value.Body
            });
        }

        public CarDTO Get(int id)
        {
            var tmp = unitOfWork.Cars.Get(id);

            return new CarDTO(  tmp.Id, 
                                tmp.Title, 
                                tmp.Volume, 
                                tmp.Year, 
                                tmp.Price, 
                                tmp.Color, 
                                tmp.TransmissionType.TransmissionType1, 
                                tmp.DriveType.DriveType1, 
                                tmp.BodyType.BodyType1, 
                                tmp.ImagePath);
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
            var tmp = unitOfWork.Cars.GetAt(index);

            return new CarDTO(tmp.Id,
                               tmp.Title,
                               tmp.Volume,
                               tmp.Year,
                               tmp.Price,
                               tmp.Color,
                               tmp.TransmissionType.TransmissionType1,
                               tmp.DriveType.DriveType1,
                               tmp.BodyType.BodyType1,
                               tmp.ImagePath);
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
            unitOfWork.Cars.RemoveAt(index);
        }

        public void Save(IEnumerable<CarDTO> value = null)
        {
            unitOfWork.Save();
        }
    }
}
