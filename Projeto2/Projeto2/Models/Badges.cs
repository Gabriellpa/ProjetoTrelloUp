using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto2.Models
{
    public class Badges
    {
        public Badges() { }
        public int attachments { get; set; }
        public List<string> attachmentsByType { get; set; }
        public int checkItems { get; set; }
        public int checkItemsChecked { get; set; }
        public int comments { get; set; }
        public bool description { get; set; }
        public string due { get; set; }
        public bool dueComplete { get; set; }
        public string fogbugz { get; set; }
        public bool subscribed { get; set; }
        public bool viewingMemberVoted { get; set; }
        public int votes { get; set; }
    }
}
