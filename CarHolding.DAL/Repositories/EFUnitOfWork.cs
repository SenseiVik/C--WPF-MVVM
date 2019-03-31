using CarHolding.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHolding.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private CarHoldingEntities db;
        private IRepository<Car> cars;
        private IRepository<BodyType> bodyTypes;
        private IRepository<DriveType> driveTypes;
        private IRepository<TransmissionType> transmissionType;

        #region Constructor
        public EFUnitOfWork()
        {
            db = new CarHoldingEntities();
        }
        #endregion

        #region Properties
        public IRepository<Car> Cars => cars = cars ?? new CarRepository(db);
        public IRepository<BodyType> BodyTypes => bodyTypes = bodyTypes ?? new BodyTypeRepository(db);
        public IRepository<DriveType> DriveTypes => driveTypes = driveTypes ?? new DriveTypeRepository(db);
        public IRepository<TransmissionType> TransmissionTypes => transmissionType = transmissionType ?? new TransmissionTypeRepository(db);
        #endregion

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
