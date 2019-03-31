using CarHolding.BLL.DTO;
using FinalProject.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infrastructure
{
    public static class Transfer
    {
        public static bool Append { get; set; }
        public static CarDTO Car { get; set; }
        public static ObservableCollection<CarDTO> Cars { get; set; }

        public static void Copy(CarDTO from, CarDTO to)
        {
            to.Title = from.Title;
            to.Volume = from.Volume;
            to.Transmission = from.Transmission;
            to.Year = from.Year;
            to.Price = from.Price;
            to.Image = from.Image;
            to.Color = from.Color;
            to.Drive = from.Drive;
            to.Body = from.Body;
        }
    }
}
