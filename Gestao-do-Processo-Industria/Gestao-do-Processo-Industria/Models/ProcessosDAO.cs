using Gestao_do_Processo_Industrial.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Hosting;

namespace Gestao_do_Processo_Industrial.Models
{
    public class ProcessosDAO
    {
        public List<Processo> ListaProcessos()
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~\App_Data\Base.json");
            var json = File.ReadAllText(caminhoArquivo);
            var listaProcessos = JsonConvert.DeserializeObject<List<Processo>>(json);

            return listaProcessos;
        }

        public bool ReescreverArquivo(List<Processo> listaProcessos)
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~\App_Data\Base.json");
            var json = JsonConvert.SerializeObject(listaProcessos, Formatting.Indented);
            File.WriteAllText(caminhoArquivo, json);

            return true;
        }

        public List<Norma> ListaNormas()
        {
            var Url = ConfigurationSettings.AppSettings["urlRNs"];
            var webRequest = WebRequest.CreateHttp(Url);
            webRequest.ContentType = "application/json";
            webRequest.Method = "GET";
            var json = webRequest.GetResponse();

            var streamDados = json.GetResponseStream();
            var reader = new StreamReader(streamDados,Encoding.UTF8);
            var JsonRetorno = reader.ReadToEnd();
            reader.Close();
            var listaNormas = JsonConvert.DeserializeObject<List<Norma>>(JsonRetorno);

            return listaNormas;
        }

        [Obsolete]
        public Norma ListaNorma(int id)
        {
            var Url = ConfigurationSettings.AppSettings["urlRN"];
            var webRequest = WebRequest.CreateHttp(Url + id);
            webRequest.ContentType = "application/json";
            webRequest.Method = "GET";
            var json = webRequest.GetResponse();

            var streamDados = json.GetResponseStream();
            var reader = new StreamReader(streamDados, Encoding.UTF8);
            var JsonRetorno = reader.ReadToEnd();
            reader.Close();
            var listaNormas = JsonConvert.DeserializeObject<Norma>(JsonRetorno);

            return listaNormas;
        }

        public Processo Inserir(Processo processo)
        {
            var listaProcessos = this.ListaProcessos();
            var maxId = listaProcessos.Max(n => n.id);
            processo.id = maxId + 1;
            listaProcessos.Add(processo);

            ReescreverArquivo(listaProcessos);

            return processo;
        }

        public Processo Atualizar(int id, Processo processo)
        {
            var listaProcessos = this.ListaProcessos();
            var itemIndex = listaProcessos.FindIndex(n => n.id == processo.id);
            if (itemIndex >= 0)
            {
                processo.id = id;
                listaProcessos[itemIndex] = processo;
            }
            else
                return null;

            ReescreverArquivo(listaProcessos);

            return processo;
        }

        public bool Deletar(int id)
        {
            var listaProcessos = this.ListaProcessos();
            var itemIndex = listaProcessos.FindIndex(n => n.id == id);
            if (itemIndex >= 0)
                listaProcessos.RemoveAt(itemIndex);
            else
                return false;

            ReescreverArquivo(listaProcessos);

            return true;
        }
    }
}