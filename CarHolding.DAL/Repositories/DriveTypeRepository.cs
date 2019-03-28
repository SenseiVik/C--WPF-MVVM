using CarHolding.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHolding.DAL.Repositories
{
    class DriveTypeRepository : IRepository<DriveType>
    {
        CarHoldingEntities db;

        public DriveTypeRepository(CarHoldingEntities dbContext)
        {
            this.db = dbContext;
        }

        ~DriveTypeRepository() => db.Dispose();

        public void CreateOrUpdate(DriveType value) => db.DriveTypes.AddOrUpdate(value);

        public DriveType Get(int id) => db.DriveTypes.Find(id);

        public IEnumerable<DriveType> GetAll() => db.DriveTypes;

        public DriveType GetAt(int index)
        {
            try
            {
                return db.DriveTypes.ToList()[index];
            }
            catch (IndexOutOfRangeException ex)
            {
                return null;
            }
        }

        public void Remove(DriveType value) => db.DriveTypes.Remove(value);

        public void RemoveAt(int index)
        {
            try
            {
                db.DriveTypes.ToList().RemoveAt(index);
            }
            catch { }
        }

        public void SaveChanges() => db.SaveChanges();
    }
}
