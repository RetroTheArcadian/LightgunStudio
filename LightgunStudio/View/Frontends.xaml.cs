using LightgunStudio.Core.Dtos;
using LightgunStudio.Core.Utilities;
using LightgunStudio.Installers.Frontends;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Windows.Controls;

namespace LightgunStudio.View
{
    /// <summary>
    /// Interaction logic for Frontends.xaml
    /// </summary>
    public partial class Frontends : UserControl
    {
        public Progress<ZipProgressDto> _progress;
        public Frontends()
        {
            InitializeComponent();
            _progress = new Progress<ZipProgressDto>();
            _progress.ProgressChanged += ReportZipProgress;
        }

        private async void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            FrontEndDto? clickedItem = ((Button)sender).DataContext as FrontEndDto;
            switch (clickedItem?.Title)
            {
                case "EsDe":
                    var dllDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    if (dllDirectory == null) return;
                    var root = Directory.GetParent(dllDirectory);
                    if (root == null) return;
                    var installer = new EmulationStationDesktopEdition();
                    grStatus.Visibility = System.Windows.Visibility.Visible;
                    await installer.DownloadAsync(pbStatus, tbStatus, root.FullName);
                    tbStatus.Text = "Unzipping Es-De please wait";
                    string zipPath = $@"{root.FullName}\Temp\es-de.zip";
                    var archive = ZipFile.OpenRead(zipPath);
                    ZipFileWithProgress.ExtractToDirectory(archive, $@"{root.FullName}\Frontends\", _progress, true);
                    archive.Dispose();
                    File.Delete($@"{root.FullName}\Temp\es-de.zip");
                    break;
                case "LaunchBox":
                    Process.Start("explorer", "https://www.launchbox-app.com/");
                    break;
            }
        }
        private void ReportZipProgress(object sender, ZipProgressDto zipProgress)
        {
            tbStatus.Text = zipProgress.Processed == zipProgress.Total ? "ES-DE was installed" : $"Unzipping {zipProgress.CurrentItem} {zipProgress.Processed}/{zipProgress.Total}";
            pbStatus.Value = (zipProgress.Processed/zipProgress.Total)*100;
        }


    }
}
