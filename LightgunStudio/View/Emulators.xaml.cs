using LightgunStudio.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace LightgunStudio.View
{
    /// <summary>
    /// Interaction logic for Emulators.xaml
    /// </summary>
    public partial class Emulators : UserControl
    {
        public Emulators()
        {
            InitializeComponent();
        }

        private async void EmulatorsInstall_Click(object sender, RoutedEventArgs e)
        {
            EmulatorsVM? vm = this.DataContext as EmulatorsVM;
            var selectedEmulators = vm?.DisplayEmulators.Where(x => x.Selected == true);
            if (selectedEmulators != null && selectedEmulators.Any())
            {
                foreach (var emulator in selectedEmulators)
                {
                    await InstallEmulator(emulator.Title);
                }
            }

            //TODO install emulators based on checked
        }

        private async Task InstallEmulator(string emulatorName)
        {
            switch (emulatorName)
            {
                case "Dolphin":
                    break;
            }
        }
    }
}
