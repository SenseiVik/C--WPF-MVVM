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

        public void CreateOrUpdate(Car value) => db.Car.AddOrUpdate<Car>(value);

        public Car Get(int id) => db.Car.Find(id);

        public IEnumerable<Car> GetAll() => db.Car;

        public Car GetAt(int index)
        {
            try
            {
                return db.Car.ToList()[index];
            }
            catch (IndexOutOfRangeException ex)
            {
                return null;
            }
        }

        public void Remove(Car value) => db.Car.Remove(value);

        public void RemoveAt(int index) 
        {
            try
            {
                db.Car.ToList().RemoveAt(index);
            }
            catch { }
        }

        public void SaveChanges() => db.SaveChanges();
    }
}
