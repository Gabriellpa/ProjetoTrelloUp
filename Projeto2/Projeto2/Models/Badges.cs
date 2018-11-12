using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto2.Models
{
    public class Badges
    {
        public Badges()
        {
            attachmentsByType = new List<object>();

        }
        public int votes { get; set; }
        [JsonIgnore]
        public List<object> attachmentsByType { get; set; }
        public bool viewingMemberVoted { get; set; }
        public bool subscribed { get; set; }
        public object fogbugz { get; set; }
        public object checkItems { get; set; }
        public object checkItemsChecked { get; set; }
        public object comments { get; set; }
        public int attachments { get; set; }
        public bool description { get; set; }
        public object due { get; set; }
        public object dueComplete { get; set; }
    }
}
