using Newtonsoft.Json;

namespace TicTacToeDiscordBot
{
    public class JsonModel
    {
        [JsonProperty("token")]
        public string ReleaseToken { get; set; }

        [JsonProperty("tokenDebug")]
        public string DebugToken { get; set; }

        [JsonProperty("spreadsheetId")]
        public string SpreadsheetId { get; set; }
    }
}
