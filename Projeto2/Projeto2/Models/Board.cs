using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto2.Models
{
    public class Board
    {
        public Board() { }
        public string id { get; set; }
        public string name { get; set; }
        public List<object> cards {get; set;}
    }

}
