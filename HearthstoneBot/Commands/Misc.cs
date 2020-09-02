using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace HearthstoneBot.Commands
{
    public class Misc : BaseCommandModule
    {
        [Command("ping")]
        [Description("Simple command for testing bot latency.")]
        public async Task Ping(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Pong! Bot delay is " + ctx.Client.Ping + "ms.").ConfigureAwait(false);
        }

    }
}
