using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto2.Models
{
    public class Card
    {
        public Card() { }
        public string id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public string due { get; set; }
        public string dueComplete { get; set; }
        public bool closed { get; set; }
        public string cover { get; set; }
        public List<string> attachments { get; set; }
        public List<string> members { get; set; }
        public List<string> labels { get; set; }
        public string url { get; set; }
        public string shortLink { get; set; }
        public string idList { get; set; }
        public string idShort { get; set; }
        public DateTime dateLastActivity { get; set; }
        public Badges badges { get; set; }
        public List<string> customFieldItems { get; set; }
    }
}
