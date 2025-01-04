using LightgunStudio.Core.Dtos;
using Newtonsoft.Json;
using System.IO;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.WebRequestMethods;
using LightgunStudio.Core.Utilities;
using System.Net.Http.Headers;
using System.Diagnostics;
using System.IO.Compression;
using Path = System.IO.Path;
using File = System.IO.File;
using AutoUpdaterDotNET;

namespace LightgunStudio
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        const string _repo = "RetroTheArcadian/LightgunStudio";
        public MainWindow()
        {
            InitializeComponent();
        }
        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await UpdateCheckAsync();
        }

        private async Task UpdateCheckAsync()
        {
            var currentVersion =  Application.ResourceAssembly.ManifestModule.Assembly.GetName().Version;
            LblVersion.Content = $"v{currentVersion}";
            var releasesUrl = $"https://api.github.com/repos/{_repo}/releases";
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("LightgunStudio", "1"));
            var releasesGet = await httpClient.GetAsync(releasesUrl);
            var releasesResult = await releasesGet.Content.ReadAsStringAsync();
            if (releasesResult == null) return;
            var releases = JsonConvert.DeserializeObject<List<Root>>(releasesResult);
            var latestReleaseVersion = releases?.OrderByDescending(x=>x.published_at).FirstOrDefault();
            if(latestReleaseVersion != null && currentVersion != null && currentVersion < Version.Parse(latestReleaseVersion.tag_name.Replace("v",string.Empty)))
            {
                var shouldUpdate = MessageBox.Show("New version found. Do you want to update?", "Update", MessageBoxButton.OKCancel);
                if (shouldUpdate == MessageBoxResult.Cancel) return;

                UpdateInfoEventArgs args = new UpdateInfoEventArgs()
                {
                    DownloadURL = latestReleaseVersion.assets[0].browser_download_url,
                };
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\Temp");
                AutoUpdater.DownloadPath = Directory.GetCurrentDirectory() + @"\Temp";
                AutoUpdater.InstallationPath = Directory.GetCurrentDirectory();
                AutoUpdater.ExecutablePath = Directory.GetCurrentDirectory();
                AutoUpdater.AppTitle = "Lightgun Studio Updater";
                AutoUpdater.HttpUserAgent = "LightgunStudio";
                if (AutoUpdater.DownloadUpdate(args))
                {
                    Close();
                }
            }
        }
    }
}