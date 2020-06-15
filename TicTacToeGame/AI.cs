using System;
using System.Collections.Generic;
using System.Text;
using DSharpPlus.Entities;

namespace TicTacToeDiscordBot.TicTacToeGame
{
    public class AI
    {
        public string Name { get; set; }
        public DiscordEmoji AiEmoji { get; set; }
        public int DifficultyLevel { get; set; }
    }
}
