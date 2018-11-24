using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto2.Services
{
    public class GoogleDriveService
    {
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/drive-dotnet-quickstart.json
        static string[] Scopes = { DriveService.Scope.DriveFile };
        static string ApplicationName = "TrelloTCC";
        private DriveService service;
        ArquivoService serviceArq;
        public GoogleDriveService()
        {
            serviceArq = new ArquivoService();
            UserCredential credential;
            try
            {
                credential = Autenticar();
                service = AbrirServico(credential);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void exportar(string caminhoArquivo)
        {             

            if (serviceArq.IdPlanilhaExiste())
            {
                string fileId = serviceArq.LerIdPlanilha();
                service.Files.Delete(fileId).Execute();
            }
            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = "teste.csv",
                MimeType = "application/vnd.google-apps.spreadsheet"
            };
            FilesResource.CreateMediaUpload request;
            using (var stream = new System.IO.FileStream(caminhoArquivo,
                                    System.IO.FileMode.Open))
            {
                request = service.Files.Create(
                    fileMetadata, stream, "text/csv");
                request.Fields = "id";
                request.Upload();
            }
            var file = request.ResponseBody;
            serviceArq.SalvarIdPlanilha(file.Id);


        }

        private Google.Apis.Auth.OAuth2.UserCredential Autenticar()
        {
            Google.Apis.Auth.OAuth2.UserCredential credenciais;

            using (var stream = new System.IO.FileStream(serviceArq.RetornaCaminhoArquivo("client_secret.json"), System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                var diretorioAtual = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                var diretorioCredenciais = serviceArq.RetornaCaminhoArquivo("credential");

                credenciais = Google.Apis.Auth.OAuth2.GoogleWebAuthorizationBroker.AuthorizeAsync(
                    Google.Apis.Auth.OAuth2.GoogleClientSecrets.Load(stream).Secrets,
                    new[] { Google.Apis.Drive.v3.DriveService.Scope.DriveFile },
                    "user",
                    System.Threading.CancellationToken.None,
                    new Google.Apis.Util.Store.FileDataStore(diretorioCredenciais, true)).Result;
            }
            //using (var stream =
            //   new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            //{                
            //    string credPath = "token.json";
            //    credenciais = GoogleWebAuthorizationBroker.AuthorizeAsync(
            //        GoogleClientSecrets.Load(stream).Secrets,
            //        new[] { Google.Apis.Drive.v3.DriveService.Scope.DriveFile },
            //        "user",
            //        CancellationToken.None,
            //        new FileDataStore(credPath, true)).Result;                
            //}
            return credenciais;
        }

        private Google.Apis.Drive.v3.DriveService AbrirServico(Google.Apis.Auth.OAuth2.UserCredential credenciais)
        {
            return new Google.Apis.Drive.v3.DriveService(new Google.Apis.Services.BaseClientService.Initializer()
            {
                HttpClientInitializer = credenciais
            });
        }
    }
}
