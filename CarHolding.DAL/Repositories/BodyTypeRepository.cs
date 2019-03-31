using CarHolding.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHolding.DAL.Repositories
{
    public class BodyTypeRepository : IRepository<BodyType>
    {
        CarHoldingEntities db;

        public BodyTypeRepository(CarHoldingEntities dbContext)
        {
            this.db = dbContext;
        }

        public BodyTypeRepository()
        {
            this.db = new CarHoldingEntities();
        }

        ~BodyTypeRepository() => db.Dispose();

        public void CreateOrUpdate(BodyType value) => db.BodyType.AddOrUpdate(value);

        public BodyType Get(int id) => db.BodyType.Find(id);

        public IEnumerable<BodyType> GetAll() => db.BodyType;

        public BodyType GetAt(int index)
        {
            try
            {
                return db.BodyType.ToList()[index];
            }
            catch (IndexOutOfRangeException ex)
            {
                return null;
            }
        }

        public void Remove(BodyType value) => db.BodyType.Remove(value);

        public void RemoveAt(int index)
        {
            try
            {
                db.BodyType.ToList().RemoveAt(index);
            }
            catch (IndexOutOfRangeException ex) { }
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
