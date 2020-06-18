﻿using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace TicTacToeDiscordBot
{
    public class Commands : BaseCommandModule
    {
        [Command("test")]
        [Description("Returns a message containing info whether the bot is running or not.")]
        // [RequireRoles(RoleCheckMode.Any, "Moderator", "Owner", "Administrator")]
        public async Task Test(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("The bot is running.");
        }

        

        // More commands can be added here. 
    }
}
