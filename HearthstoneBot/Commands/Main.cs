using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;
using HearthstoneBot.Functions;
using System.Linq;

namespace HearthstoneBot.Commands
{
    public class Main : BaseCommandModule
    {
        [Command("card")]
        [Description("Gets an image of a card.")]
        
        public async Task Card(CommandContext ctx, params string[] attr)
        {
            var attrList = attr.OfType<string>().ToList();

            bool gold = false;

            if (attrList.Contains("Golden"))
            {
                gold = true;
                attrList.Remove("Golden");
            }

            var cardName = string.Join(" ", attrList.ToArray());
            
            var card = CardHelper.GetCardInfo(cardName);
            var cardImage = CardHelper.GetCardImage(card, gold);

            await ctx.Channel.SendMessageAsync(cardImage);
        }


        [Command("attack")]
        [Description("Gets attack value of a card.")]

        public async Task Attack(CommandContext ctx, string attr)
        {
            if (!CardHelper.IsMinion(attr))
                await ctx.Channel.SendMessageAsync("That's not a minon.");
            else
                await ctx.Channel.SendMessageAsync(CardHelper.GetAtk(attr));
        }

        [Command("health")]
        [Description("Gets health value of a card.")]

        public async Task Health(CommandContext ctx, string attr)
        {
            if (!CardHelper.IsMinion(attr))
                await ctx.Channel.SendMessageAsync("That's not a minon.");
            else
                await ctx.Channel.SendMessageAsync(CardHelper.GetHp(attr));
        }

        [Command("cost")]
        [Description("Gets cost of a card.")]

        public async Task Cost(CommandContext ctx, string attr)
        {
            await ctx.Channel.SendMessageAsync(CardHelper.GetCost(attr));
        }

        [Command("rarity")]
        [Description("Gets rarity of a card.")]

        public async Task Rarity(CommandContext ctx, string attr)
        {
            await ctx.Channel.SendMessageAsync(CardHelper.GetRarity(attr));
        }

        [Command("race")]
        [Description("Gets race of a card.")]

        public async Task Race(CommandContext ctx, string attr)
        {
            if (!CardHelper.IsMinion(attr))
                await ctx.Channel.SendMessageAsync("That's not a minon.");
            else
                await ctx.Channel.SendMessageAsync(CardHelper.GetRace(attr));
        }

        [Command("faction")]
        [Description("Gets faction of a card.")]

        public async Task Faction(CommandContext ctx, string attr)
        {
            if (!CardHelper.IsMinion(attr))
                await ctx.Channel.SendMessageAsync("That's not a minon.");
            else
                await ctx.Channel.SendMessageAsync(CardHelper.GetFaction(attr));
        }

        [Command("getId")]
        public async Task GetId (CommandContext ctx, string cardName)
        {
            await ctx.Channel.SendMessageAsync(CardHelper.GetId(cardName));
        }
        [Command("getType")]
        public async Task GetType(CommandContext ctx, string cardName)
        {
            await ctx.Channel.SendMessageAsync(CardHelper.GetType(cardName));
        }
    }
    
}
