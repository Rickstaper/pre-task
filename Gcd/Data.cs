using Newtonsoft.Json;

namespace Gcd
{
    public class Data
    {
        [JsonProperty("method_name")]
        public string Method { get; set; }
        [JsonProperty("time")]
        public string Time { get; set; }

        public Data(string method, string time)
        {
            Method = method;
            Time = time;
        }
    }
}
