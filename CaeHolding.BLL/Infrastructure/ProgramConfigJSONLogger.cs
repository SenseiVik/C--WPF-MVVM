using CarHolding.BLL.Interfaces;
using Newtonsoft.Json;
using System.IO;

namespace CarHolding.BLL.Infrastructure
{
    public class ProgramConfigJSONLogger : ILogger<ProgramConfig>
    {
        public ProgramConfig Load(string path)
        {
            path += ".json";

            if (!File.Exists(path))
                return null;

            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<ProgramConfig>(json);
        }

        public void Save(string path, ProgramConfig value)
        {
            path += ".json";

            string json = JsonConvert.SerializeObject(value, Formatting.Indented);
            File.WriteAllText(path, json);
        }
    }
}
