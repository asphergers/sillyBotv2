using System;

namespace cSharpSillyBot {
    class Program {
        public static Dictionary<ulong, Guild_Settings> _map = new Dictionary<ulong, Guild_Settings>();

        public static void Main(string[] args) {

            Bot bot = new Bot();
            bot.RunAsync().GetAwaiter().GetResult();
        }
    }
}
