using System;
using System.Collections.Generic;
using System.Text;
using DSharpPlus.Entities;

namespace TicTacToeDiscordBot.TicTacToeGame
{
    public class AI
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public DiscordEmoji AiEmoji { get; set; }
        public string Difficulty { get; set; }

        public AI(ulong id, string name, DiscordEmoji aiEmoji, string difficulty)
        {
            Id = id;
            Name = name;
            AiEmoji = aiEmoji;
            Difficulty = difficulty;
        }
    }
}
