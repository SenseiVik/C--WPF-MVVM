using System;
using CarHolding.BLL.Types;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarHolding.BLL.DTO
{
    public class CarDTO : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private string title;
        private double volume;
        private string color;
        private int year;
        private int price;
        private TransmissionType transmission;
        private DriveType drive;
        private BodyType body;
        private string image;

        #region Constructor
        public CarDTO( int id,
                    string title, 
                    double volume, 
                    int year, 
                    int price, 
                    string color,
                    string transmission, 
                    string drive, 
                    string body,
                    string image)
        {
            this.id = id;
            this.title = title;
            this.volume = volume;
            this.year = year;
            this.price = price;
            this.color = color;
            this.image = image;

            this.drive = (DriveType)Enum.Parse(typeof(DriveType), drive);
            this.transmission = (TransmissionType)Enum.Parse(typeof(TransmissionType), transmission);
            this.body = (BodyType)Enum.Parse(typeof(BodyType), body);
        }

        public CarDTO()
        {
            Title = "None";
            Volume = 0;
            Color = "None";
            Year = 0;
            Price = 0;
            Transmission = TransmissionType.Automatic;
            Drive = DriveType.BackWheel;
            Body = BodyType.Coupe;
            Image = @"..\Icon\car.png";
        }
        #endregion

        #region Properties

        public string Title
        {
            get => title;
            set
            {
                title = value;
                Notify();
            }
        }

        public string Color
        {
            get => color;
            set
            {
                color = value;
                Notify();
            }
        }

        public double Volume
        {
            get => volume;
            set
            {
                volume = value;
                Notify();
            }
        }

        public int Year
        {
            get => year;
            set
            {
                year = value;
                Notify();
            }
        }

        public int Price
        {
            get => price;
            set
            {
                price = value;
                Notify();
            }
        }

        public TransmissionType Transmission
        {
            get => transmission;
            set
            {
                transmission = value;
                Notify();

            }
        }

        public DriveType Drive
        {
            get => drive;
            set
            {
                drive = value;
                Notify();
            }
        }

        public BodyType Body
        {
            get => body;
            set
            {
                body = value;
                Notify();
            }
        }

        public string Image
        {
            get => image;
            set
            {
                image = value;
                Notify();
            }
        }

        public int Id
        {
            get => id;
            set
            {
                id = value;
                Notify();
            }
        }
        #endregion

        private void Notify([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
