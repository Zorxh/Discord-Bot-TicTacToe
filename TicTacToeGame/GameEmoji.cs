using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;

namespace TicTacToeDiscordBot.TicTacToeGame
{
    public static class GameEmoji
    {
        public static DiscordEmoji X;
        public static DiscordEmoji O;
        public static DiscordEmoji Field;
        public static DiscordEmoji One;
        public static DiscordEmoji Two;
        public static DiscordEmoji Three;
        public static DiscordEmoji Four;
        public static DiscordEmoji Five;
        public static DiscordEmoji Six;
        public static DiscordEmoji Seven;
        public static DiscordEmoji Eight;
        public static DiscordEmoji Nine;

        public static void InitEmoji(CommandContext ctx)
        {
            X = BuildEmoji(ctx, ":x:");
            O = BuildEmoji(ctx, ":blue_circle:");
            Field = BuildEmoji(ctx, ":black_large_square:");
            One = BuildEmoji(ctx, ":one:");
            Two = BuildEmoji(ctx, ":two:");
            Three = BuildEmoji(ctx, ":three:");
            Four = BuildEmoji(ctx, ":four:");
            Five = BuildEmoji(ctx, ":five:");
            Six = BuildEmoji(ctx, ":six:");
            Seven = BuildEmoji(ctx, ":seven:");
            Eight = BuildEmoji(ctx, ":eight:");
            Nine = BuildEmoji(ctx, ":nine:");
        }

        private static DiscordEmoji BuildEmoji(CommandContext ctx, string emoji)
        {
            return DiscordEmoji.FromName(ctx.Client, emoji);
        }
    }
}
