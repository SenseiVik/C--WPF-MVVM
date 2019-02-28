using FinalProject.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Model
{
    public class Car : INotifyPropertyChanged, ICloneable
    {
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
        public Car(string title, 
                    double volume, 
                    int year, 
                    int price, 
                    string color,
                    TransmissionType transmission, 
                    DriveType drive, 
                    BodyType body,
                    string image)
        {
            this.title = title;
            this.volume = volume;
            this.year = year;
            this.price = price;
            this.color = color;
            this.transmission = transmission;
            this.drive = drive;
            this.image = image;
            this.body = body;
        }

        public Car()
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

        public static ObservableCollection<Car> GetCars()
        {
            return new ObservableCollection<Car>()
            {
                new Car("Honda Accord", 2.4, 2011, 24000, "Black", TransmissionType.Manual, DriveType.FrontWheel, BodyType.Sedan, @"..\Image\hondaAccord.jpg"),
                new Car("Honda HR-V", 3.2, 2018, 34000, "DarkRed", TransmissionType.Automatic, DriveType.Full, BodyType.Crossover, @"..\Image\hondaHRV.jpg"),
                new Car("Honda Civic", 2.0, 2017, 27000, "Green", TransmissionType.Manual, DriveType.FrontWheel, BodyType.Coupe, @"..\Image\hondaCivic.jpg")
            };
        }

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
