using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infrastructure
{
    public class ComboBoxEnum
    {
        public Array BodyTypes { get; set; }
        public Array TransmissionType { get; set; }
        public Array DriveType { get; set; }

        public ComboBoxEnum()
        {
            BodyTypes = Enum.GetValues(typeof(BodyType));
            TransmissionType = Enum.GetValues(typeof(TransmissionType));
            DriveType = Enum.GetValues(typeof(DriveType));
        }
    }
}
