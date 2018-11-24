using Projeto2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Projeto2.Services
{
    public class TrelloService
    {
        private string token = "cfc54b0d82d2b1a158290327e876d61201d8950f93d4f5eceffc3f9326248465";
        private string chave = "2ab512c448a93c480bd47af6923dadde";
        private const string URL = "https://api.trello.com/1/";
        private string urlParameters;
        ArquivoService serviceTeste;
        public TrelloService()
        {
            urlParameters = string.Format("?key={0}&token={1}", chave, token);
            serviceTeste = new ArquivoService();
        }

        public List<Card> GetCards(string idLista)
        {
            string listaUrl = string.Format("lists/{0}/cards", idLista) + urlParameters;
            List<CardList> lista = new List<CardList>();
            List<Card> listaRetorno = new List<Card>();

            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri(URL);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync(listaUrl).Result;
                if (response.IsSuccessStatusCode)
                {
                    string dataObjects = response.Content.ReadAsStringAsync().Result;
                    lista = JsonConvert.DeserializeObject<List<CardList>>(dataObjects);
                }
            }
                        
            foreach(var card in lista)
            {
                listaRetorno.Add(GetCard(card.id));
            }

            return listaRetorno;
        }

        public Card GetCard(string idCard) {
            Card card = new Card();
            string cardUrl = string.Format("card/{0}", idCard) + urlParameters;
            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri(URL);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync(cardUrl).Result;
                if (response.IsSuccessStatusCode)
                {
                    string dataObjects = response.Content.ReadAsStringAsync().Result;
                    card = JsonConvert.DeserializeObject<Card>(dataObjects);
                }
            }                        

            return card;
        }

        public void Robo()
        {
            List<List<string>> ids = serviceTeste.lerIds();
            if(ids != null)
            {
                TratarDados(new DadosTrello() {backlog = ids[0],todo = ids[1], done = ids[2] });
            }
        }

        public void TratarDados(DadosTrello dados)
        {
            ArquivoService serviceArq = new ArquivoService();
            List<List<Card>> listaBackLog = new List<List<Card>>();
            List<List<Card>> listaTodo = new List<List<Card>>();
            List<List<Card>> listaDone = new List<List<Card>>();
            int qtdBackLog = 0;
            int qtdTodo = 0;
            int qtdDone = 0;
            
            foreach (string backlog in dados.backlog)
            {
                List<Card> retorno = GetCards(backlog);
                qtdBackLog += retorno.Count;
                listaBackLog.Add(retorno);
            }
           
            foreach (string todo in dados.todo)
            {
                List<Card> retorno = GetCards(todo);
                qtdTodo += retorno.Count;
                listaTodo.Add(retorno);
            }
            
            foreach (string done in dados.done)
            {
                List<Card> retorno = GetCards(done);
                qtdDone += retorno.Count;
                listaDone.Add(retorno);
            }
            if (serviceArq.ArquivoSimplesExiste())
            {
                serviceArq.AtualizarPlanilhaSimples(qtdBackLog, qtdTodo, qtdDone);
            }
            else
            {
                serviceArq.CriarPlanilhaSimples(qtdBackLog, qtdTodo, qtdDone);
            }           
        }

    }
}
