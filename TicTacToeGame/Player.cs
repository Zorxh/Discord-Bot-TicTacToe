using DSharpPlus.Entities;

namespace TicTacToeDiscordBot.TicTacToeGame
{
    public class Player
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public DiscordEmoji PlayerEmoji { get; set; }

        public Player(ulong id, string name, DiscordEmoji playerEmoji)
        {
            Id = id;
            Name = name;
            PlayerEmoji = playerEmoji;
        }
    }
}
