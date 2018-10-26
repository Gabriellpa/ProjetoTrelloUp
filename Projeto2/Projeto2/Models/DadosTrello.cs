using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto2.Models
{
    public class DadosTrello
    {
        public DadosTrello() { }

        public List<object> backlog { get; set; }
        public List<object> todo { get; set; }
        public List<object> done { get; set; }

    }
}
