using Newtonsoft.Json;
using System;
using System.Text;

namespace cSharpSillyBot {
    public struct ConfigJson {
        [JsonProperty("token")]
        public string Token {get; private set; }

        [JsonProperty("prefix")]
        public string Prefix {get; private set; }
    }
}