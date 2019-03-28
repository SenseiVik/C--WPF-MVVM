using CarHolding.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHolding.DAL.Repositories
{
    class TransmissionTypeRepository : IRepository<TransmissionType>
    {
        CarHoldingEntities db;

        public TransmissionTypeRepository(CarHoldingEntities dbContext)
        {
            this.db = dbContext;
        }

        ~TransmissionTypeRepository() => db.Dispose();

        public void CreateOrUpdate(TransmissionType value) => db.TransmissionTypes.AddOrUpdate(value);

        public TransmissionType Get(int id) => db.TransmissionTypes.Find(id);

        public IEnumerable<TransmissionType> GetAll() => db.TransmissionTypes;

        public TransmissionType GetAt(int index)
        {
            try
            {
                return db.TransmissionTypes.ToList()[index];
            }
            catch (IndexOutOfRangeException ex)
            {
                return null;
            }
        }

        public void Remove(TransmissionType value) => db.TransmissionTypes.Remove(value);

        public void RemoveAt(int index)
        {
            try
            {
                db.TransmissionTypes.ToList().RemoveAt(index);
            }
            catch { }
        }

        public void SaveChanges() => db.SaveChanges();
    }
}
