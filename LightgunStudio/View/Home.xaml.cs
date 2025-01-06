using LightgunStudio.Core.Utilities;
using System.Windows;
using System.Windows.Controls;

namespace LightgunStudio.View
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
        }

        private async void btnEsDl_Click(object sender, RoutedEventArgs e)
        {
            FolderStructure.CreateFolderStructure();
            //var t = new Installers.Frontends.EmulationStationDesktopEdition();
            //await t.DownloadAsync();
        }
    }
}
