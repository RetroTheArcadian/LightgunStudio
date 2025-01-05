using LightgunStudio.Core.Utilities;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using LightgunStudio.Core.Dtos.Gitlab;

namespace LightgunStudio.Installers.Frontends
{
    class EmulationStationDesktopEdition
    {
        readonly string releasesUrl = "https://gitlab.com/api/v4/projects/es-de%2Femulationstation-de/releases";
        string latestReleaseUrl = string.Empty;

        public async Task DownloadAsync()
        {
            await GetLatest();
            if (latestReleaseUrl == string.Empty) return;
            using (var client = new HttpClientDownloadWithProgress(latestReleaseUrl, @"C:\Arcade\LightgunStudio\Temp\es-de.zip"))
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
            var releasesGet = await httpClient.GetAsync(releasesUrl);
            var releasesResult = await releasesGet.Content.ReadAsStringAsync();
            if (releasesResult == null) return;
            var releases = JsonConvert.DeserializeObject<List<Root>>(releasesResult);
            var latestReleaseVersion = releases?.OrderByDescending(x => x.released_at).FirstOrDefault();
            var latestRelease = latestReleaseVersion?.assets.links.FirstOrDefault(x => x.name.Contains("x64_Portable"));
            if (latestRelease == null) return;
            latestReleaseUrl = latestRelease.direct_asset_url;
        }
    }
}
