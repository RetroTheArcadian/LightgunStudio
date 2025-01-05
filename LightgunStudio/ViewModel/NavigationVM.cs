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

        public ICommand HomeCommand { get; set; }
        public ICommand GunsCommand { get; set; }
        public ICommand EmulatorsCommand { get; set; }

        private void Home(object obj) => CurrentView = new HomeVM();
        private void Guns(object obj) => CurrentView = new GunsVM();
        private void Emulators(object obj) => CurrentView = new EmulatorsVM();

        public NavigationVM()
        {
            HomeCommand = new RelayCommand(Home);
            GunsCommand = new RelayCommand(Guns);
            EmulatorsCommand = new RelayCommand(Emulators);

            // Startup Page
            CurrentView = new HomeVM();
        }
    }
}
