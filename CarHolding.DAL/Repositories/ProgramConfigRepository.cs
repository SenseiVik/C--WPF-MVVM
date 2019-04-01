using CarHolding.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHolding.DAL.Repositories
{
    public class ProgramConfigRepository : IRepository<ProgramConfig>
    {
        private CarHoldingEntities db;

        public ProgramConfigRepository()
        {
            db = new CarHoldingEntities();
        }

        public ProgramConfigRepository(CarHoldingEntities dbContext)
        {
            this.db = dbContext;
        }

        public void CreateOrUpdate(ProgramConfig value)
        {
            db.ProgramConfig.AddOrUpdate(value);
        }

        public ProgramConfig Get(int id)
        {
            return db.ProgramConfig.Find(id);
        }

        public IEnumerable<ProgramConfig> GetAll()
        {
            return db.ProgramConfig;
        }

        public ProgramConfig GetAt(int index)
        {
            try
            {
                return db.ProgramConfig.ToList()[index];
            }
            catch
            {
                return null;
            }
        }

        public void Remove(ProgramConfig value)
        {
            db.ProgramConfig.Remove(value);
        }

        public void RemoveAt(int index)
        {
            try
            {
                var tmp = db.ProgramConfig.ToList()[index];
                db.ProgramConfig.Remove(tmp);
            }
            catch
            {
                return;
            }
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
