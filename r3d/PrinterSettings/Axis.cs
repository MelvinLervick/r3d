using Newtonsoft.Json;

namespace r3d.PrinterSettings
{
    public class Axis
    {
        [JsonProperty("minimum")]
        public int Minimum { get; set; }

        [JsonProperty("maximum")]
        public int Maximum { get; set; }

        [JsonProperty("pointspermillimeter")]
        public int PointsPerMillimeter { get; set; }
    }
}