using Consultoria_e_Assessoria.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Hosting;

namespace Consultoria_e_Assessoria.Models
{
    public class ConsultoriaDAO
    {
        public List<Consultoria> ListaConsultorias()
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~\App_Data\Base.json");
            var json = File.ReadAllText(caminhoArquivo);
            var listaConsultorias = JsonConvert.DeserializeObject<List<Consultoria>>(json);

            return listaConsultorias;
        }

        public bool ReescreverArquivo(List<Consultoria> listaConsultorias)
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~\App_Data\Base.json");
            var json = JsonConvert.SerializeObject(listaConsultorias, Formatting.Indented);
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
            var reader = new StreamReader(streamDados, Encoding.UTF8);
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

        public Consultoria Inserir(Consultoria consultoria)
        {
            var listaConsultorias = this.ListaConsultorias();
            var maxId = listaConsultorias.Max(n => n.id);
            consultoria.id = maxId + 1;
            listaConsultorias.Add(consultoria);

            ReescreverArquivo(listaConsultorias);

            return consultoria;
        }

        public Consultoria Atualizar(int id, Consultoria consultoria)
        {
            var listaConsultorias = this.ListaConsultorias();
            var itemIndex = listaConsultorias.FindIndex(n => n.id == consultoria.id);
            if (itemIndex >= 0)
            {
                consultoria.id = id;
                listaConsultorias[itemIndex] = consultoria;
            }
            else
                return null;

            ReescreverArquivo(listaConsultorias);

            return consultoria;
        }

        public bool Deletar(int id)
        {
            var listaConsultorias = this.ListaConsultorias();
            var itemIndex = listaConsultorias.FindIndex(n => n.id == id);
            if (itemIndex >= 0)
                listaConsultorias.RemoveAt(itemIndex);
            else
                return false;

            ReescreverArquivo(listaConsultorias);

            return true;
        }
    }
}