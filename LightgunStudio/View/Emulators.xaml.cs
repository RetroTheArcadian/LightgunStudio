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

        private void EmulatorsInstall_Click(object sender, RoutedEventArgs e)
        {
            EmulatorsVM? vm = this.DataContext as EmulatorsVM;
            var selectedEmulators = vm?.DisplayEmulators.Select(x => x.Selected == true);
            //TODO install emulators based on checked
        }
    }
}
