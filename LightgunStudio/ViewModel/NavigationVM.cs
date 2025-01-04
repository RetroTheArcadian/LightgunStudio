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

        private void Home(object obj) => CurrentView = new HomeVM();
        private void Guns(object obj) => CurrentView = new GunsVM();

        public NavigationVM()
        {
            HomeCommand = new RelayCommand(Home);
            GunsCommand = new RelayCommand(Guns);

            // Startup Page
            CurrentView = new HomeVM();
        }
    }
}
