using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

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
