﻿using System;
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
            ArquivoService serviceArq = new ArquivoService();
            ViewBag.JaEscolheu = serviceArq.EscolheuListas();
            return View();
        }

        public IActionResult Authorize()
        {
            return View();
        }

        public IActionResult Authsuccess()
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
            
            TrelloService serviceTrello = new TrelloService();            
            DadosTrello dataPost = dadosTrello;
            ArquivoService serviceArq = new ArquivoService();
            serviceArq.criarPastaArquivos();
            serviceArq.salvarIdsLista(dataPost);
            serviceTrello.TratarDados(dataPost);                        
            return dataPost;
        }

        [HttpPut]
        public void Atualizar()
        {
            TrelloService serviceTrello = new TrelloService();
            serviceTrello.Robo();
        }
        
        [HttpPut]
        public String RetornarArquivo()
        {
              ArquivoService serviceArq = new ArquivoService();
              return serviceArq.RetornarArquivo();
        }

        [HttpGet]
        public void ExportarArquivo()
        {
            GoogleDriveService service = new GoogleDriveService();
            ArquivoService serviceArq = new ArquivoService();
            service.exportar(serviceArq.RetornaCaminhoArquivo());
        }
    }


}
