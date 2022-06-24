using System;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;


namespace cSharpSillyBot.Commands {
    public class Basics : BaseCommandModule {
        [Command("ping")]
        public async Task ping(CommandContext ctx) {
            await ctx.Channel.SendMessageAsync("pong").ConfigureAwait(false);
        }
    }
}