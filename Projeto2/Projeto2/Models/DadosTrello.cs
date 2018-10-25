using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto2.Models
{
    public class DadosTrello
    {
        
        private string backlog;
        private string todo;
        private string done;

        public string Backlog { get => backlog; set => backlog = value; }
        public string Todo { get => todo; set => todo = value; }
        public string Done { get => done; set => done = value; }
    }
}
