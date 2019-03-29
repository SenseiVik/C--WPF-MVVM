using CarHolding.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHolding.DAL.Repositories
{
    public class CarRepository : IRepository<Car>
    {
        CarHoldingEntities db;

        public CarRepository(CarHoldingEntities dbContext)
        {
            this.db = dbContext;
        }

        ~CarRepository() => db.Dispose();

        public void CreateOrUpdate(Car value) => db.Cars.AddOrUpdate<Car>(value);

        public Car Get(int id) => db.Cars.Find(id);

        public IEnumerable<Car> GetAll() => db.Cars;

        public Car GetAt(int index)
        {
            try
            {
                return db.Cars.ToList()[index];
            }
            catch (IndexOutOfRangeException ex)
            {
                return null;
            }
        }

        public void Remove(Car value) => db.Cars.Remove(value);

        public void RemoveAt(int index) 
        {
            try
            {
                db.Cars.ToList().RemoveAt(index);
            }
            catch { }
        }

        public void SaveChanges() => db.SaveChanges();
    }
}
