using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHolding.DAL.Interfaces
{
    interface IRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T GetAt(int index);
        void CreateOrUpdate(T value);
        void Remove(T value);
        void RemoveAt(int index);
        void SaveChanges();
    }
}
