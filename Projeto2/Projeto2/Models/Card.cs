using Newtonsoft.Json;
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
            checkItemStates = new List<object>();
            idCheckList = new List<string>();
            idLabels = new List<string>();
            idMembers = new List<string>();
            idMembersVoted = new List<string>();
            labels = new List<object>();
        }
        public string id { get; set; }
        public Badges badges { get; set; }
        public List<object> checkItemStates { get; set; }
        public object closed { get; set; }
        public DateTime dateLastActivity { get; set; }
        public string desc { get; set; }
        [JsonIgnore]
        public string descData { get; set; }
        public string due { get; set; }
        public bool dueComplete { get; set; }
        public string idAttachmentCover { get; set; }
        public string idBoard { get; set; }
        public List<string> idCheckList { get; set; }
        public List<string> idLabels { get; set; }
        public string idList { get; set; }
        public List<string> idMembers { get; set; }
        public List<string> idMembersVoted { get; set; }
        public short idShort { get; set; }
        public List<object> labels { get; set; }
        public bool manualCoverAttachment { get; set; }
        public string name { get; set; }
        public float pos { get; set; }
        public string shortLink { get; set; }
        public string shortUrl { get; set; }
        public string subscribed { get; set; }
        public string url { get; set; }


    }
    public class CardList
    {
        public CardList()
        {
            members = new List<object>();
            attachments = new List<object>();
            labels = new List<object>();
            customFieldItems = new List<object>();
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