using LightgunStudio.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
