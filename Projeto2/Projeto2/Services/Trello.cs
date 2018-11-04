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

        public TrelloService()
        {
            urlParameters = string.Format("?key={0}&token={1}", chave, token);
        }
        
        public string GetCards(string idLista)
        {
            string lista = string.Format("lists/{0}/cards", idLista) + urlParameters;
            
            using (HttpClient client = new HttpClient()) {

                client.BaseAddress = new Uri(URL);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                HttpResponseMessage response = client.GetAsync(lista).Result;  
                if (response.IsSuccessStatusCode)
                {
                    var dataObjects = response.Content.ReadAsStringAsync().Result;
                    
                    foreach (var d in dataObjects)
                    {
                        var a = JsonConvert.DeserializeObject(d.ToString());
                    }
                }
            }
           
            
            return string.Empty;
        }        
    }
}
