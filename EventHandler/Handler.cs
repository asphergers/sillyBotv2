using System;
using DSharpPlus;
using DSharpPlus.EventArgs;

namespace cSharpSillyBot.EventHandler {
    public static class Handler {
        public static async Task MessageHandler(DiscordClient client, MessageCreateEventArgs args) {
            if (args.Message.Content.ToLower().Contains("linux") && !args.Message.Content.ToLower().Contains("gnu")) {
                await args.Message.RespondAsync("You mean GNU/Linux - Richard Stallman").ConfigureAwait(false);
            }
        }
    }
}