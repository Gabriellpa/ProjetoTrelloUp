using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto2.Models
{
    public class DadosTrello
    {

        public List<List<ListaT>> backlog { get; set; }
        public List<List<ListaT>> todo { get; set; }
        public List<List<ListaT>> done { get; set; }

    }
}
