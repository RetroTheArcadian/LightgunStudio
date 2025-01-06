using LightgunStudio.Core.Dtos.AutoConfigDto;
using Newtonsoft.Json;

namespace LightgunStudio.Core.Utilities
{
    public class AutoConfig
    {
        public AutoConfigDto? GetAutoConfig()
        {
            var dllDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            if (dllDirectory == null) return null;
            var root = Directory.GetParent(dllDirectory);
            if (root == null) return null;
            using (var r = new StreamReader(dllDirectory + @"\Templates\Config.json"))
            {
                string json = r.ReadToEnd();
                if (json == null) return null;
                return JsonConvert.DeserializeObject<AutoConfigDto>(json);
            }
        }
        public List<Lightgun> GetActiveLightguns(List<string> hids)
        {
            var lightguns = new List<Lightgun>();
            var cfg = GetAutoConfig();
            foreach (var hid in hids) { 
                var lightgun = cfg?.Lightguns.FirstOrDefault(x=> hid.Contains(x.Hid));
                if(lightgun != null) {  lightguns.Add(lightgun); }
            }
            return lightguns.Distinct().ToList();
        }
    }
}
