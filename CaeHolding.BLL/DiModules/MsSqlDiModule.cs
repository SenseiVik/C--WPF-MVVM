using CarHolding.BLL.Services;
using CarHolding.BLL.DTO;
using CarHolding.BLL.Interfaces;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHolding.BLL.DiModules
{
    public class MsSqlDiModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IService<CarDTO>>().To<MsSqlServerService>();
        }
    }
}
