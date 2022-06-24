using System;
using System.Net;

namespace cSharpSillyBot.CommandCode {
    public class Quote {
        public string getQuote() {
            string url = "https://inspirobot.me/api?generate=true";
            return quote(url).image;
        }

        public Item quote(string url) {
            string quote = new WebClient().DownloadString(url);
            return new Item {
                image = quote
            };
        }
    }

    public class Item {
        public string? image { get; set; }
    }
}