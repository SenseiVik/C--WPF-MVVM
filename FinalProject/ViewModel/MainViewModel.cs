using CarHolding.BLL.Infrastructure;
using CarHolding.BLL.DTO;
using CarHolding.BLL.Interfaces;
using FinalProject.Infrastructure;
using FinalProject.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace FinalProject.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<CarDTO> cars;
        private CarDTO selectedCar;
        private ProgramConfig config;
        private Dictionary<string, string> language;
        private ILogger<ProgramConfig> programConfigLogger;
        private IService<CarDTO> service;

        #region Commands
        public ICommand LoadCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand ChangeThemeCommand { get; set; }
        public ICommand ChangeLanguageCommand { get; set; }
        public ICommand AppendCarCommand { get; set; }
        public ICommand EditCarCommand { get; set; }
        public ICommand SortCommand { get; set; }
        #endregion

        #region Constructor
        public MainViewModel(IService<CarDTO> service)
        {
            this.service = service;
            this.programConfigLogger = new ProgramConfigJSONLogger();

            RemoveCommand = new RelayCommand(RemoveMethod, x => SelectedCar != null);
            ChangeLanguageCommand = new RelayCommand(ChangeLanguageMethod);
            ChangeThemeCommand = new RelayCommand(ChangeThemeMethod);
            AppendCarCommand = new RelayCommand(AppendCarMethod);
            EditCarCommand = new RelayCommand(EditCarMethod, x => SelectedCar != null);
            SortCommand = new RelayCommand(SortMethod);
            SaveCommand = new RelayCommand(SaveMethod);
            LoadCommand = new RelayCommand(LoadMethod);
        }

        private void LoadMethod(object obj)
        {
            ProgramConfig res = programConfigLogger.Load("ProgramConfig");

            if (res != null)
            {
                Config = res;
                ChangeLanguageMethod(Config.Language);
                ChangeThemeMethod(Config.LightTheme);
            }
            else
            {
                Language = LanguageManager.GetDictionaryEnglish();
                Config = new ProgramConfig();
                Config.Language = "ENG";
                Config.LightTheme = true;
            }

            var tmp = service.GetAll();
            Cars = tmp != null ? new ObservableCollection<CarDTO>(tmp) : new ObservableCollection<CarDTO>();
        }

        private void SaveMethod(object obj)
        {
            programConfigLogger.Save("ProgramConfig", Config);
            service.Save(Cars);
        }


        #endregion

        #region Properties
        public ProgramConfig Config
        {
            get => config;
            set
            {
                config = value;
                Notify();
            }
        }


        public Dictionary<string, string> Language
        {
            get => language;
            set
            {
                language = value;
                Notify();
            }
        }

        public ObservableCollection<CarDTO> Cars
        {
            get => cars;
            set
            {
                cars = value;
                Notify();
            }
        }

        public CarDTO SelectedCar
        {
            get => selectedCar;
            set
            {
                selectedCar = value;
                Notify();
            }
        }

        #endregion


        private void RemoveMethod(object obj)
        {
            service.Remove(SelectedCar);
            service.Save();
            Cars.Remove(SelectedCar);
        }


        private void ChangeThemeMethod(object parameter)
        {
            bool theme = Convert.ToBoolean(parameter);

            Config.LightTheme = theme;

            ResourceDictionary[] dict = new ResourceDictionary[0];

            dict = theme ? Theme.GetLightTheme() : Theme.GetDarkTheme();

            App.Current.Resources.MergedDictionaries.Clear();

            foreach (var elem in dict)
            {
                App.Current.Resources.MergedDictionaries.Add(elem);
            }
        }

        private void AppendCarMethod(object parameter)
        {
            Transfer.Car = new CarDTO();
            Transfer.Cars = Cars;
            Transfer.Append = true;

            CarView carView = new CarView();
            carView.ShowDialog();

            service.CreateOrUpdate(Transfer.Car, Cars);
            service.Save();
        }

        private void EditCarMethod(object parameter)
        {
            Transfer.Car = SelectedCar;
            Transfer.Cars = Cars;
            Transfer.Append = false;

            CarView carView = new CarView();
            carView.ShowDialog();

            service.CreateOrUpdate(SelectedCar, Cars);
            service.Save();
        }

        private void SortMethod(object parameter)
        {
            int index = Convert.ToInt32(parameter);

            switch (index)
            {
                case 0:
                    Cars = new ObservableCollection<CarDTO>(Cars.OrderBy(x => x.Title));
                    break;
                case 1:
                    Cars = new ObservableCollection<CarDTO>(Cars.OrderBy(x => x.Volume));
                    break;
                case 2:
                    Cars = new ObservableCollection<CarDTO>(Cars.OrderBy(x => x.Color));
                    break;
                case 3:
                    Cars = new ObservableCollection<CarDTO>(Cars.OrderBy(x => x.Year));
                    break;
                case 4:
                    Cars = new ObservableCollection<CarDTO>(Cars.OrderBy(x => x.Price));
                    break;
                case 5:
                    Cars = new ObservableCollection<CarDTO>(Cars.OrderBy(x => x.Transmission));
                    break;
                case 6:
                    Cars = new ObservableCollection<CarDTO>(Cars.OrderBy(x => x.Drive));
                    break;
                case 7:
                    Cars = new ObservableCollection<CarDTO>(Cars.OrderBy(x => x.Body));
                    break;
            }
        }

        private void ChangeLanguageMethod(object parameter)
        {
            string choise = parameter.ToString();

            switch (choise)
            {
                case "ENG":
                    Language = LanguageManager.GetDictionaryEnglish();
                    Config.Language = "ENG";
                    Config.SelectedLanguageIndex = 0;
                    break;

                case "RUS":
                    Language = LanguageManager.GetDictionaryRussian();
                    Config.Language = "RUS";
                    Config.SelectedLanguageIndex = 1;
                    break;
            }
        }

        public void Notify([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
