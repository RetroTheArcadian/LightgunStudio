using Newtonsoft.Json;

namespace LightgunStudio.Core.Dtos.AutoConfigDto
{
    public partial class AutoConfigDto
    {
        [JsonProperty("Lightguns", NullValueHandling = NullValueHandling.Ignore)]
        public required List<Lightgun> Lightguns { get; set; }
    }

    public partial class Lightgun
    {
        [JsonProperty("HID", NullValueHandling = NullValueHandling.Ignore)]
        public required string Hid { get; set; }

        [JsonProperty("Name", NullValueHandling = NullValueHandling.Ignore)]
        public required string Name { get; set; }
    }
}
