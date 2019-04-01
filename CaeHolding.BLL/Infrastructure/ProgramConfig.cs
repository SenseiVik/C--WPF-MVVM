using CarHolding.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHolding.BLL.Infrastructure
{
    public class ProgramConfig
    {
        public bool LightTheme { get; set; }
        public string Language { get; set; }
        public int SelectedLanguageIndex { get; set; }

        public ProgramConfig() { }
    }
}
