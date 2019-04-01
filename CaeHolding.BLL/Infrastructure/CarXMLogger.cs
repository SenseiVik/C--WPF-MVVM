using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CarHolding.BLL.DTO;
using CarHolding.BLL.Interfaces;

namespace CarHolding.BLL.Infrastructure
{
    public class CarXMLogger : ILogger<IEnumerable<CarDTO>>
    {
        private XmlSerializer xml = new XmlSerializer(typeof(ProgramConfig));

        public CarXMLogger()
        {
            xml = new XmlSerializer(typeof(ProgramConfig));
        }

        public IEnumerable<CarDTO> Load(string path)
        {
            path += ".xml";

            if (!File.Exists(path))
                return null;

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                object obj = xml.Deserialize(fs);

                if (obj is ProgramConfig)
                    return obj as IEnumerable<CarDTO>;
                else
                    return null;
            }
        }

        public void Save(string path, IEnumerable<CarDTO> value)
        {
            path += ".xml";

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, value);
            }

        }
    }
}
