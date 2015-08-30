using Newtonsoft.Json;

namespace r3d.PrinterSettings
{
    public class Settings
    {
        [JsonProperty("x-axis")]
        public Axis XAxis { get; set; }

        [JsonProperty("y-axis")]
        public Axis YAxis { get; set; }

        [JsonProperty("z-axis")]
        public Axis ZAxis { get; set; }
    }
}