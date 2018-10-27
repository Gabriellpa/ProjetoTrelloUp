using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto2.Models
{
    public class Card
    {
        public Card()
        {
            members = new List<object>();
        }
        public string id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public string due { get; set; }
        public bool dueComplete { get; set; }
        public object closed { get; set; }
        public string cover { get; set; }
        public List<object> attachments { get; set; }
        public List<object> members { get; set; }
        public List<object> labels { get; set; }
        public string url { get; set; }
        public string shortLink { get; set; }
        public string idList { get; set; }
        public short idShort { get; set; }
        public DateTime dateLastActivity { get; set; }
        public object badges { get; set; }
        public List<object> customFieldItems { get; set; }
    }
}