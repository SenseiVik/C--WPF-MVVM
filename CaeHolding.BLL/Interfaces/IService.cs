using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHolding.BLL.Interfaces
{
    public interface IService<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T GetAt(int index);
        void CreateOrUpdate(T value, IEnumerable<T> collection = null);
        void Remove(T value);
        void RemoveAt(int index);
        void Save(IEnumerable<T> value = null);
    } 
}
