using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto2.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

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
        public Board DataTrello([FromBody] Board dados)
        {
            //Retornando tudo null;
            Board dadosTrello = dados;

            return dadosTrello;
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
