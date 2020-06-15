using DSharpPlus.Entities;

namespace TicTacToeDiscordBot.TicTacToeGame
{
    public class Field
    {
        public DiscordEmoji FieldEmoji { get; set; }
        public int FieldValue { get; set; }

        public Field(DiscordEmoji fieldEmoji, int fieldValue)
        {
            FieldEmoji = fieldEmoji;
            FieldValue = fieldValue;
        }
    }
}
