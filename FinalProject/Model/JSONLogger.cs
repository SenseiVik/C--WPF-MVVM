using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Infrastructure;
using Newtonsoft.Json;

namespace FinalProject.Model
{
    class JSONLogger : ILogger
    {
        public ProgramConfig Load(string path)
        {
            path += ".json";

            if (!File.Exists(path))
                return null;

            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<ProgramConfig>(json);
        }

        public void Save(string path, ProgramConfig config)
        {
            path += ".json";

            string json = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText(path, json);
        }
    }
}
