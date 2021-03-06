﻿using CarHolding.BLL.DTO;
using FinalProject.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FinalProject.ViewModel
{
    public class CarViewModel : INotifyPropertyChanged
    {
        private CarDTO car;

        public ICommand OkCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public CarDTO Car
        {
            get => car;
            set
            {
                car = value;
                Notify();
            }
        }

        public CarViewModel()
        {
            Car = Transfer.Car.Clone() as CarDTO;

            CancelCommand = new RelayCommand(UserCancel);
            OkCommand = new RelayCommand(UserConfirm);
        }

        private void UserConfirm(object parameter)
        {
            if (Transfer.Append)
            {
                Transfer.Cars.Add(Car);
                Transfer.Car = Car;
            }
            else
                Transfer.Copy(Car, Transfer.Car);

            (parameter as Window).Close();
            Transfer.Append = false;
        }

        private void UserCancel(object parameter)
        {
            (parameter as Window).Close();
            Transfer.Append = false;
        }

        private void Notify([CallerMemberName] string propertyName= "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
