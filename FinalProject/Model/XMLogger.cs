using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using FinalProject.Infrastructure;

namespace FinalProject.Model
{
    public class XMLogger : ILogger
    {
        private XmlSerializer xml = new XmlSerializer(typeof(ProgramConfig));

        public XMLogger()
        {
            xml = new XmlSerializer(typeof(ProgramConfig));
        }

        public ProgramConfig Load(string path)
        {
            path += ".xml";

            if (!File.Exists(path))
                return null;

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                object obj = xml.Deserialize(fs);

                if (obj is ProgramConfig)
                    return obj as ProgramConfig;
                else
                    return null;
            }
        }

        public void Save(string path, ProgramConfig config)
        {
            path += ".xml";

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, config);
            }

        }
    }
}
