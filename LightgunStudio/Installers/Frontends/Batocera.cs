using System.Net.Http.Headers;
using System.Net.Http;
using LightgunStudio.Core.Utilities;

namespace LightgunStudio.Installers.Frontends
{
    public class Batocera
    {
        string batoceraUpdates = @"https://updates.batocera.org/";
        string latestReleaseFilename = string.Empty;

        public async Task DownloadAsync()
        {
            await GetLatest();
            if (latestReleaseFilename == string.Empty) return;
            using (var client = new HttpClientDownloadWithProgress(batoceraUpdates + latestReleaseFilename, $@"C:\Arcade\LightgunStudio\Temp\{latestReleaseFilename}"))
            {
                client.ProgressChanged += (fileTotalSize, fileBytesDownloaded, fileProgressPercentage) =>
                {
                    Console.WriteLine(fileTotalSize.ToString());
                    Console.WriteLine(fileBytesDownloaded.ToString());
                    Console.WriteLine(fileProgressPercentage.ToString());
                };
                await client.StartDownload();
            }
        }

        public async Task GetLatest()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("LightgunStudio", "1"));
            var releasesGet = await httpClient.GetAsync(batoceraUpdates + "installs.txt");
            var releasesResult = await releasesGet.Content.ReadAsStringAsync();
            if (releasesResult == null) return;
            var releasesList = new List<string>(releasesResult.Split("\r\n"));
            var latest = releasesList.FirstOrDefault(x=> x.Contains("batocera-x86_64"));
            if(latest == null) return;
            latestReleaseFilename = latest;
        }
    }
}
