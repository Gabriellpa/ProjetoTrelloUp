﻿using Projeto2.Models;
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
        string PastaArquivos;

        public ArquivoService()
        {
            PastaArquivos = Environment.CurrentDirectory+"\\arquivos\\";

        }

        public void CriarPlanilhaSimples(int qtdCardsBackLog, int qtdCardsTodo, int qtdCardsDone)
        {
            StringBuilder conteudoCsv = new StringBuilder();

            string nomeArquivo = "teste.csv";
            
            conteudoCsv.AppendLine("data, qtdBacklog,qtdTodo, qtdDone");//headers
            string linha = string.Format("{0},{1},{2},{3}", DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss"), qtdCardsBackLog, qtdCardsTodo, qtdCardsDone);
            conteudoCsv.AppendLine(linha);

            string caminhoArquivo = PastaArquivos + nomeArquivo;
            File.WriteAllText(caminhoArquivo, conteudoCsv.ToString());            
        }

        public void LerArquivo(string arquivo ="teste.csv")
        {
            string caminho = Environment.CurrentDirectory + arquivo;

        }

        public void salvarIdsLista(DadosTrello ids)
        {
            StringBuilder conteudoTxt = new StringBuilder();
            string backLog = String.Join(",", ids.backlog.ToArray());
            string todo = String.Join(",", ids.todo.ToArray());
            string done = String.Join(",", ids.done.ToArray());
            conteudoTxt.AppendLine(backLog);
            conteudoTxt.AppendLine(todo);
            conteudoTxt.AppendLine(done);

            string caminhoArquivo = PastaArquivos + "ids.txt";
            File.WriteAllText(caminhoArquivo, conteudoTxt.ToString());
        }

        public List<List<string>> lerIds()
        {
            List<List<string>> retorno = new List<List<string>>();            

            using (var reader = new StreamReader(PastaArquivos + "ids.txt"))
            {
                string linha;
                for(byte linhas = 0; linhas<3; linhas++)
                {
                    linha = reader.ReadLine();
                    retorno.Add(linha.Split(",").ToList());
                }                
            }
            return retorno;
        }
        //metodo para atualizar arquivo csv pelo robo
        public void AtualizarPlanilhaSimples(int qtdCardsBackLog, int qtdCardsTodo, int qtdCardsDone)
        { 
            
            string nomeArquivo = "teste.csv";
            using (StreamWriter sw = File.AppendText(PastaArquivos + nomeArquivo))
            {
                string linha = string.Format("{0},{1},{2},{3}", DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss"), qtdCardsBackLog, qtdCardsTodo, qtdCardsDone);
                sw.WriteLine(linha);
            }          
        }

        public bool ArquivoSimplesExiste()
        {
            return File.Exists(PastaArquivos + "teste.csv");
        }

        public bool EscolheuListas()
        {
            return File.Exists(PastaArquivos + "ids.txt");
        }

        public bool IdPlanilhaExiste()
        {
            return File.Exists(PastaArquivos + "idPlanilha.txt");
        }

        public void criarPastaArquivos()
        {
            string caminho = Environment.CurrentDirectory + "\\arquivos";
            System.IO.Directory.CreateDirectory(caminho);
        }
        
        public string RetornarArquivo()
        {
            string nomeArquivo = "teste.csv";
            string arquivo = string.Empty;
            using (StreamReader sw = new StreamReader(PastaArquivos + nomeArquivo))
            {
                arquivo = sw.ReadToEnd().ToString();
            }   
            return arquivo;
        }

        public string RetornaCaminhoArquivo(string arquivo = "teste.csv")
        {
            return PastaArquivos + arquivo;
        }

        public void SalvarIdPlanilha(string id)
        {
            StringBuilder conteudoTxt = new StringBuilder();
            conteudoTxt.AppendLine(id);
            string caminhoArquivo = PastaArquivos + "idPlanilha.txt";
            File.WriteAllText(caminhoArquivo, conteudoTxt.ToString());
        }

        public string LerIdPlanilha()
        {
            string linha;
            using (var reader = new StreamReader(PastaArquivos + "idPlanilha.txt"))
            {                                
                linha = reader.ReadLine();                 
            }
            return linha.Trim();
        }
    }
}
