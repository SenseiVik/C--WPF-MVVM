using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHolding.BLL.Interfaces
{
    public interface ILogger<T>
    {
        void Save(string path, T value);
        T Load(string path);
    }
}
