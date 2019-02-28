using FinalProject.Model;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infrastructure
{
    public class DImodule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ILogger>().To<JSONLogger>();
        }
    }
}
