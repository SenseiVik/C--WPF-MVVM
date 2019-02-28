using FinalProject.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace FinalProject.Infrastructure
{
    public class ProgramConfig
    {
        public ObservableCollection<Car> Cars { get; set; }
        public bool LightTheme { get; set; }
        public int LanguageIndex { get; set; }
        public string Language { get; set; }

        public ProgramConfig() { }
    }
}
