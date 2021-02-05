using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace Gestao_de_normas.Models
{
    public class NormasDAO
    {
        public List<Norma> ListaNormas()
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~\App_Data\Base.json");
            var json = File.ReadAllText(caminhoArquivo);
            var listaNormas = JsonConvert.DeserializeObject<List<Norma>>(json);

            return listaNormas;
        }

        public bool ReescreverArquivo(List<Norma> listaNormas)
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~\App_Data\Base.json");
            var json = JsonConvert.SerializeObject(listaNormas, Formatting.Indented);
            File.WriteAllText(caminhoArquivo, json);

            return true;
        }
        public Norma Inserir(Norma norma)
        {
            var listaNormas = this.ListaNormas();
            var maxId = listaNormas.Max(n => n.id);
            norma.id = maxId + 1;
            listaNormas.Add(norma);

            ReescreverArquivo(listaNormas);

            return norma;
        }

        public Norma Atualizar(int id, Norma norma)
        {
            var listaNormas = this.ListaNormas();
            var itemIndex = listaNormas.FindIndex(n => n.id == norma.id);
            if (itemIndex >= 0)
            {
                norma.id = id;
                listaNormas[itemIndex] = norma;
            }
            else
                return null;

            ReescreverArquivo(listaNormas);

            return norma;
        }

        public bool Deletar(int id)
        {
            var listaNormas = this.ListaNormas();
            var itemIndex = listaNormas.FindIndex(n => n.id == id);
            if (itemIndex >= 0)
                listaNormas.RemoveAt(itemIndex);
            else
                return false;

            ReescreverArquivo(listaNormas);

            return true;
        }
    }
}