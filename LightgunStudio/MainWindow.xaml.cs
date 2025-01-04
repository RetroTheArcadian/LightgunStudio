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
            var releasesUrl = $"https://api.github.com/repos/{_repo}/releases";
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("LightgunStudio", "1"));
            var releasesGet = await httpClient.GetAsync(releasesUrl);
            var releasesResult = await releasesGet.Content.ReadAsStringAsync();
            if (releasesResult == null) return;
            var releases = JsonConvert.DeserializeObject<List<Root>>(releasesResult);
            var latestReleaseVersion = releases?.OrderByDescending(x=>x.published_at).FirstOrDefault();
            if(latestReleaseVersion != null && currentVersion != null && currentVersion != Version.Parse(latestReleaseVersion.tag_name.Replace("v",string.Empty)))
            {
                var downloadPath = Directory.GetCurrentDirectory() + @"\" + latestReleaseVersion.assets[0].name;
                using (var client = new HttpClientDownloadWithProgress(latestReleaseVersion.assets[0].browser_download_url, downloadPath))
                {
                    client.ProgressChanged += (totalFileSize, totalBytesDownloaded, progressPercentage) =>
                    {
                        Console.WriteLine($"{progressPercentage}% ({totalBytesDownloaded}/{totalFileSize})");
                    };

                    await client.StartDownload();
                    try
                    {
                        string zipPath = Directory.GetCurrentDirectory() + @"\" + latestReleaseVersion.assets[0].name;
                        Console.WriteLine("Zip's path: " + zipPath);
                        //Declare a temporary path to unzip your files
                        string tempPath = Path.Combine(Directory.GetCurrentDirectory(), "tempUnzip");
                        Directory.CreateDirectory(tempPath);
                        string extractPath = Directory.GetCurrentDirectory();
                        ZipFile.ExtractToDirectory(zipPath, tempPath);

                        //build an array of the unzipped files
                        string[] files = Directory.GetFiles(tempPath);

                        foreach (string file in files)
                        {
                            FileInfo f = new FileInfo(file);
                            //Check if the file exists already, if so delete it and then move the new file to the extract folder
                            if (File.Exists(Path.Combine(extractPath, f.Name)))
                            {
                                File.Delete(Path.Combine(extractPath, f.Name));
                                File.Move(f.FullName, Path.Combine(extractPath, f.Name));
                            }
                            else
                            {
                                File.Move(f.FullName, Path.Combine(extractPath, f.Name));
                            }
                        }
                        //Delete the temporary directory.
                        Directory.Delete(tempPath,true);
                        MessageBox.Show("Download Complete, Starting new App now", "UpdateCheck");
                        Process.Start("LightgunStudio.exe", Directory.GetCurrentDirectory());
                        Close();
                    }
                    catch (Exception exception)
                    {
                        var ex = exception;
                        //return (1); // 1 = extract error
                    }

                }
                
            }
        }
    }
}