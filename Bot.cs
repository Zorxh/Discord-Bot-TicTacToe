using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TicTacToeDiscordBot.bin;
using TicTacToeDiscordBot.TicTacToeGame;

namespace TicTacToeDiscordBot
{
    public class Bot
    {
        public DiscordClient Client { get; private set; }
        public CommandsNextExtension Commands { get; private set; }

        public async Task RunAsync()
        {
            DiscordConfiguration config = new DiscordConfiguration
            {
                Token = GetTokenFromJsonFile(), // Insert personal token here.
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                LogLevel = LogLevel.Debug,
                UseInternalLogHandler = true
            };

            Client = new DiscordClient(config);

            Client.Ready += OnClientReady;

            CommandsNextConfiguration commandsConfig = new CommandsNextConfiguration
            {
                StringPrefixes = new[] { "!", "?", "." }, // Can be changed to fit user liking.
                EnableDms = false,
                EnableMentionPrefix = true,
                DmHelp = true
            };

            Client.UseInteractivity(new InteractivityConfiguration
            {
                Timeout = TimeSpan.FromMinutes(2) // Can be tuned to user liking. 2 = 2 minutes.
            });

            Commands = Client.UseCommandsNext(commandsConfig);

            Commands.RegisterCommands<Commands>();
            Commands.RegisterCommands<TicTacToe>();

            await Client.ConnectAsync();

            await Task.Delay(-1);
        }

        private Task OnClientReady(ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }

        // 2 methods to get the token for the bot. The file must be placed in the bin/Debug||Release/netcoreapp3.1 folder for the method to be able to find it.
        // Or else you will need to specify your personal path for the file.
        private string GetTokenFromTxtFile()
        {
            using StreamReader inputStream = new StreamReader("token.txt");
            return inputStream.ReadToEnd();
        }

        private string GetTokenFromJsonFile()
        {
            using FileStream fs = File.OpenRead("token.json");
            using StreamReader sr = new StreamReader(fs, new UTF8Encoding(false));
            string json = sr.ReadToEnd();

            JsonModel configJson = JsonConvert.DeserializeObject<JsonModel>(json);

            return configJson.Token;
        }

    }
}
