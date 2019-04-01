using CarHolding.BLL.DTO;
using CarHolding.BLL.Infrastructure;
using CarHolding.BLL.Interfaces;
using CarHolding.BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHolding.BLL.DiModules
{
    public class JsonDiModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IService<CarDTO>>().To<FileSaverService>();
            this.Bind<ILogger<IEnumerable<CarDTO>>>().To<CarJSONLogger>();
        }
    }
}
