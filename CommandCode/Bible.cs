using System;
using System.Net;
using Newtonsoft.Json;

namespace cSharpSillyBot.CommandCode {
    public class Bible {
        public string getFinal() {
            string url = "https://labs.bible.org/api/?passage=random&type=json";
            Item? final = getVerse(url);
            return $"{final.bookname} {final.chapter}:{final.verse}\n{final.text}";
        }

        public class Item {
            public string? bookname { get; set; }
            public string? chapter { get; set; }
            public string? verse { get; set; }
            public string? text { get; set; }
        }

         public static Item? getVerse(string url) {
            string json = new WebClient().DownloadString(url);
            List<Item>? items = JsonConvert.DeserializeObject<List<Item>>(json);
            return new Item {
                bookname = items[0].bookname,
                chapter = items[0].chapter,
                verse = items[0].verse,
                text = items[0].text
            };
        }
    }
}