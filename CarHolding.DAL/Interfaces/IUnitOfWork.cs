using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHolding.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Car> Cars { get; }
        IRepository<BodyType> BodyTypes { get; }
        IRepository<DriveType> DriveTypes { get; }
        IRepository<TransmissionType> TransmissionTypes { get; }

        void SaveChanges();
    }
}
