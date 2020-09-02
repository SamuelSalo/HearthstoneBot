using Newtonsoft.Json;

namespace HearthstoneBot
{
    public struct Config
    {
        [JsonProperty("token")]
        public string Token { get; private set; }
        [JsonProperty("prefix")]
        public string Prefix { get; private set; }
        [JsonProperty("key")]
        public string Key { get; private set; }
        [JsonProperty("host")]
        public string Host { get; private set; }
        [JsonProperty("url")]
        public string Url { get; private set; }
    }
}