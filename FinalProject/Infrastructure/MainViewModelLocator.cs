using CarHolding.BLL.DiModules;
using FinalProject.ViewModel;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infrastructure
{
    public class MainViewModelLocator
    {
        IKernel kernel;

        public MainViewModelLocator()
        {
            // Just use DiModules
            kernel = new StandardKernel(new MsSqlDiModule()); 
        }

        public MainViewModel MainViewModel
        {
            get => kernel.Get<MainViewModel>();
        }
    }
}
