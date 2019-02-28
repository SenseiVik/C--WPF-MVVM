using FinalProject.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Model
{
    public interface ILogger
    {
        void Save(string path, ProgramConfig config);
        ProgramConfig Load(string path);
    }
}
