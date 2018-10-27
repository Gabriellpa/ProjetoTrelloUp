using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto2.Models
{
    public class Badges
    {
        public object attachments { get; set; }
        public List<object> attachmentsByType { get; set; }
        public object checkItems { get; set; }
        public object checkItemsChecked { get; set; }
        public object comments { get; set; }
        public object description { get; set; }
        public object due { get; set; }
        public object dueComplete { get; set; }
        public object fogbugz { get; set; }
        public object subscribed { get; set; }
        public object viewingMemberVoted { get; set; }
        public object votes { get; set; }
    }
}
