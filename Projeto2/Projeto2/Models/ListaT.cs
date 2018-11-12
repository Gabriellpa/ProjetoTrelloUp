using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto2.Models
{
    public class ListaT
    {
        public ListaT()
        {
            cards = new List<Card>();
        }
        public List<Card> cards { get; set; }
    }
}
