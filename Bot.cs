using System;
using cSharpSillyBot.Commands;
using cSharpSillyBot.EventHandler;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft;
using Newtonsoft.Json;

namespace cSharpSillyBot {
    public class Bot {

        public DiscordClient Client { get; private set; }
        public CommandsNextExtension Commands { get; private set; }
        public async Task RunAsync() {

            String json = string.Empty;

            FileStream fs = File.OpenRead("./config.json");
            StreamReader sr = new StreamReader(fs, new UTF8Encoding(false));
            json = await sr.ReadToEndAsync().ConfigureAwait(false);

            var configJson = JsonConvert.DeserializeObject<ConfigJson>(json);

            DiscordConfiguration config = new DiscordConfiguration {
                Token = configJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                MinimumLogLevel = Microsoft.Extensions.Logging.LogLevel.Debug
            };

            Client = new DiscordClient(config);

            Client.Ready += onClientReady;

            var commandsConfig = new CommandsNextConfiguration {
                StringPrefixes = new string[] { configJson.Prefix },

            };

            Commands = Client.UseCommandsNext(commandsConfig);
            Client.MessageCreated += Handler.MessageHandler; 
            Commands.RegisterCommands<Basics>();
            Commands.RegisterCommands<MainCommands>();
            
            await Client.ConnectAsync();
            await Task.Delay(-1);
        }

        private Task onClientReady(object sender, ReadyEventArgs e) {
            Console.WriteLine("bot is online");
            return Task.CompletedTask;
        }
    }
}