using Newtonsoft.Json;

namespace TicTacToeDiscordBot
{
    public class JsonModel
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
