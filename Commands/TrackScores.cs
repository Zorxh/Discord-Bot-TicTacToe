using System;
using System.Collections.Generic;
using System.Text;
using DSharpPlus.CommandsNext;
using TicTacToeDiscordBot.External_Dependencies;

namespace TicTacToeDiscordBot.Commands
{
    public class TrackScores : BaseCommandModule
    {
        ScoreDatabase sdb = new ScoreDatabase();
    }
}
