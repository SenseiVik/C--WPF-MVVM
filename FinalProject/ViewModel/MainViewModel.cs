using FinalProject.Infrastructure;
using FinalProject.Model;
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
        private ObservableCollection<Car> cars;
        private Car selectedCar;
        private ProgramConfig config;
        private Dictionary<string, string> language;
        private ILogger logger;

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
        public MainViewModel(ILogger logger)
        {
            this.logger = logger;

            RemoveCommand = new RelayCommand(x => Cars.Remove(SelectedCar), x => SelectedCar != null);
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
            ProgramConfig res = logger.Load("data");

            if (res != null)
            {
                Config = res;
                ChangeLanguageMethod(Config.Language);
                ChangeThemeMethod(Config.LightTheme);
                Cars = Config.Cars;
            }
            else
            {
                Cars = Car.GetCars();
                Language = LanguageManager.GetDictionaryEnglish();
                Config = new ProgramConfig();
                Config.Language = "ENG";
                Config.LightTheme = true;
            }
        }

        private void SaveMethod(object obj)
        {
            Config.Cars = Cars;
            logger.Save("data", Config);
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

        public ObservableCollection<Car> Cars
        {
            get => cars;
            set
            {
                cars = value;
                Notify();
            }
        }

        public Car SelectedCar
        {
            get => selectedCar;
            set
            {
                selectedCar = value;
                Notify();
            }
        }

        #endregion

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
            Transfer.SelectedCar = new Car();
            Transfer.Cars = Cars;
            Transfer.Append = true;

            CarView carView = new CarView();

            carView.Show();
        }

        private void EditCarMethod(object parameter)
        {
            Transfer.SelectedCar = SelectedCar;
            Transfer.Cars = Cars;
            Transfer.Append = false;

            CarView carView = new CarView();

            carView.Show();
        }

        private void SortMethod(object parameter)
        {
            int index = Convert.ToInt32(parameter);

            switch (index)
            {
                case 0:
                    Cars = new ObservableCollection<Car>(Cars.OrderBy(x => x.Title));
                    break;
                case 1:
                    Cars = new ObservableCollection<Car>(Cars.OrderBy(x => x.Volume));
                    break;
                case 2:
                    Cars = new ObservableCollection<Car>(Cars.OrderBy(x => x.Color));
                    break;
                case 3:
                    Cars = new ObservableCollection<Car>(Cars.OrderBy(x => x.Year));
                    break;
                case 4:
                    Cars = new ObservableCollection<Car>(Cars.OrderBy(x => x.Price));
                    break;
                case 5:
                    Cars = new ObservableCollection<Car>(Cars.OrderBy(x => x.Transmission));
                    break;
                case 6:
                    Cars = new ObservableCollection<Car>(Cars.OrderBy(x => x.Drive));
                    break;
                case 7:
                    Cars = new ObservableCollection<Car>(Cars.OrderBy(x => x.Body));
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
                    break;

                case "RUS":
                    Language = LanguageManager.GetDictionaryRussian();
                    Config.Language = "RUS";
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
