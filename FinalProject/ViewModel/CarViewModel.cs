﻿using FinalProject.Infrastructure;
using FinalProject.Model;
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
        private Car car;

        public ICommand OkCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public Car Car
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
            Car = Transfer.SelectedCar.Clone() as Car;
            //Car = new Car();
            //Transfer.Copy(Transfer.SelectedCar, Car);

            CancelCommand = new RelayCommand(CancelMethod);
            OkCommand = new RelayCommand(OkMethod);
        }

        private void OkMethod(object parameter)
        {
            if (Transfer.Append)
                Transfer.Cars.Add(Car);
            else
                Transfer.Copy(Car, Transfer.SelectedCar);

            (parameter as Window).Close();
            Transfer.Append = false;
        }

        private void CancelMethod(object parameter)
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