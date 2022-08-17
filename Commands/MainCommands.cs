using System;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using cSharpSillyBot.CommandCode;

namespace cSharpSillyBot.Commands {
    public class MainCommands : BaseCommandModule {

        [Command("date")]
        [Description("return the true date")]
        public async Task date(CommandContext ctx, string wildcard) {
            Date main = new Date();
            if (wildcard.Equals("*")) {
                await ctx.Channel.SendMessageAsync(main.getAll()).ConfigureAwait(false);
                return;
            }

            await ctx.Channel.SendMessageAsync(main.getDate(DateTime.Now.Month)).ConfigureAwait(false);
            return;
        }

        [Command("bible")]
        [Description("returns a random bible verse")]
        public async Task date(CommandContext ctx) {
            Bible quote = new Bible();
            await ctx.Channel.SendMessageAsync(quote.getFinal()).ConfigureAwait(false);
        }

        [Command("qt")]
        [Description("returns an amazing inspiring quote")]
        public async Task quote(CommandContext ctx) {
            Quote quote = new Quote();
            await ctx.Channel.SendMessageAsync(quote.getQuote()).ConfigureAwait(false);
        }

        [Command("fxtoggle")]
        [Description("toggles auto twitter fx")]
        public async Task fx_toggle(CommandContext ctx) {

            if (Program._map.ContainsKey(ctx.Guild.Id)) {
                Program._map[ctx.Guild.Id].Fx_Twitter = !Program._map[ctx.Guild.Id].Fx_Twitter;
            } else {
                Program._map.Add(ctx.Guild.Id, new Guild_Settings(){
                        Fx_Twitter = true
                });
            }

            await ctx.Message.Channel.SendMessageAsync($"sender: {ctx.User}");
            await ctx.Message.Channel.SendMessageAsync($"fxtoggle: {Program._map[ctx.Guild.Id].Fx_Twitter}");
        }
    }
}
