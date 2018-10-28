using Projeto2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto2.Services
{
    public class ArquivoService
    {
        public void CriarPlanilha(List<List<ListaT>> lista)
        {
            StringBuilder conteudoCsv = new StringBuilder();

            foreach (var item in lista)
            {
                foreach(var itemLista in item){

                    
                    string nomeArquivo = itemLista.name +".csv";

                    foreach(var card in itemLista.cards)
                    {

                    }

                    string caminhoArquivo = "C:\\CSV\\" + nomeArquivo;
                    File.WriteAllText(caminhoArquivo, conteudoCsv.ToString());
                }
                
            }
            
        }

        public void ContabilizarAtividades (DadosTrello dados)
        {
            int qtdBacklog = dados.backlog[0][0].cards.Count;
            int qtdTodo = dados.todo[0][0].cards.Count;
            int qtdDone= dados.done[0][0].cards.Count;

        }
    }
}
