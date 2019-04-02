using CarHolding.BLL.DTO;
using CarHolding.BLL.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHolding.BLL.Infrastructure
{
    class CarJSONLogger : ILogger<IEnumerable<CarDTO>>
    {
        public IEnumerable<CarDTO> Load(string path)
        {
            path += ".json";

            if (!File.Exists(path))
                return null;

            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<IEnumerable<CarDTO>>(json);
        }

        public void Save(string path, IEnumerable<CarDTO> value = null)
        {
            path += ".json";

            string json = JsonConvert.SerializeObject(value, Formatting.Indented);
            File.WriteAllText(path, json);
        }
    }
}
