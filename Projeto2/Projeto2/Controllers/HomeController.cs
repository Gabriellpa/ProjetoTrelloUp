using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto2.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Projeto2.Services;
//heroku "https://projeto2trello.herokuapp.com/"
namespace Projeto2.Controllers
{
    [Produces("application/json")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Listas()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public DadosTrello Post([FromBody] DadosTrello dadosTrello)
        {
            List<List<Card>> listaBackLog = new List<List<Card>>();
            List<List<Card>> listaTodo = new List<List<Card>>();
            List<List<Card>> listaDone = new List<List<Card>>();

            DadosTrello dataPost = dadosTrello;
            TrelloService service = new TrelloService();

            //BackLog
            foreach (string backlog in dataPost.backlog)
            {
                List<Card> retorno = service.GetCards(backlog); // seria oq viria da modal para cada lista que o cara escolher
                listaBackLog.Add(retorno);
            }

            //TODO
            foreach (string backlog in dataPost.todo)
            {
                List<Card> retorno = service.GetCards(backlog); // seria oq viria da modal para cada lista que o cara escolher
                listaTodo.Add(retorno);
            }

            //DONE
            foreach (string backlog in dataPost.done)
            {
                List<Card> retorno = service.GetCards(backlog); // seria oq viria da modal para cada lista que o cara escolher
                listaDone.Add(retorno);
            }

            //Aqui já tem as 3 listas para usar na planilha  

            //  ArquivoService service = new ArquivoService();

            //service.CriarPlanilha(dadosTrello.backlog);
            //service.CriarPlanilha(dadosTrello.todo);
            //service.CriarPlanilha(dadosTrello.done);

            return dataPost;
        }

        [HttpPost]
        public void DataTrellos([FromBody] JObject dados)
        {
            //Retornando tudo null;
            string dadosTrello = null;

            // return dadosTrello;
        }
    }


}
