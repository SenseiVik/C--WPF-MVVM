using CarHolding.DAL.Interfaces;
using CarHolding.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHolding.DAL.Repositories
{
    public class DriveTypeRepository : IRepository<DriveType>
    {
        CarHoldingEntities db;

        public DriveTypeRepository(CarHoldingEntities dbContext)
        {
            this.db = dbContext;
        }

        ~DriveTypeRepository() => db.Dispose();

        public void CreateOrUpdate(DriveType value) => db.DriveType.AddOrUpdate(value);

        public DriveType Get(int id) => db.DriveType.Find(id);

        public IEnumerable<DriveType> GetAll() => db.DriveType;

        public DriveType GetAt(int index)
        {
            try
            {
                return db.DriveType.ToList()[index];
            }
            catch (IndexOutOfRangeException ex)
            {
                return null;
            }
        }

        public void Remove(DriveType value) => db.DriveType.Remove(value);

        public void RemoveAt(int index)
        {
            try
            {
                db.DriveType.ToList().RemoveAt(index);
            }
            catch { }
        }

        public void SaveChanges() => db.SaveChanges();
    }
}
