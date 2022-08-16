using System;
using DSharpPlus;
using DSharpPlus.EventArgs;

namespace cSharpSillyBot.EventHandler {
    public static class Handler {
        public static async Task MessageHandler(DiscordClient client, MessageCreateEventArgs args) {
            if (args.Message.Content.ToLower().Contains("linux") && !args.Message.Content.ToLower().Contains("gnu")) {
                await args.Message.RespondAsync("You mean GNU/Linux - Richard Stallman").ConfigureAwait(false);
            }

            if (Program._map.ContainsKey(args.Guild.Id)) {
                if (args.Message.Content.StartsWith("https://twitter.com")) {
                    string original_link = args.Message.Content;

                    await args.Message.DeleteAsync().ConfigureAwait(false);

                    string fx_link = original_link.Substring(0, 8) + "fx" + original_link.Substring(8);

                    await args.Channel.SendMessageAsync(fx_link).ConfigureAwait(false);
                }
            }
        }
    }
}
