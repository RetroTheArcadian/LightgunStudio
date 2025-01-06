using LightgunStudio.Utilities;
using System.Windows.Input;

namespace LightgunStudio.ViewModel
{
    class NavigationVM : ViewModelBase
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand DependenciesCommand { get; set; }
        public ICommand EmulatorsCommand { get; set; }
        public ICommand FrontendsCommand { get; set; }
        public ICommand GunsCommand { get; set; }
        public ICommand HomeCommand { get; set; }
        public ICommand SettingsCommand { get; set; }
        public ICommand SoftwareCommand { get; set; }

        private void Dependencies(object obj) => CurrentView = new DependenciesVM();
        private void Emulators(object obj) => CurrentView = new EmulatorsVM();
        private void Frontends(object obj) => CurrentView = new FrontendsVM();
        private void Guns(object obj) => CurrentView = new GunsVM();
        private void Home(object obj) => CurrentView = new HomeVM();
        private void Settings(object obj) => CurrentView = new SettingsVM();
        private void Software(object obj) => CurrentView = new SoftwareVM();

        public NavigationVM()
        {
            DependenciesCommand = new RelayCommand(Dependencies);
            EmulatorsCommand = new RelayCommand(Emulators);
            FrontendsCommand = new RelayCommand(Frontends);
            GunsCommand = new RelayCommand(Guns);
            HomeCommand = new RelayCommand(Home);
            SettingsCommand = new RelayCommand(Settings);
            SoftwareCommand = new RelayCommand(Software);

            // Startup Page
            CurrentView = new HomeVM();
        }
    }
}
