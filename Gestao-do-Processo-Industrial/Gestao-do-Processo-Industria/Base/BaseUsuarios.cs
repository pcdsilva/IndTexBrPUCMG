using Gestao_do_Processo_Industria.DTOs;
using System.Collections.Generic;

namespace Gestao_do_Processo_Industria.Base
{
    public class BaseUsuarios
    {
        public static IEnumerable<Usuario> Usuarios()
        {
            return new List<Usuario>
            {
                new Usuario { Nome = "Murilo", Senha = "123456" },
                new Usuario { Nome = "Paulo", Senha = "123456" },
                new Usuario { Nome = "Andrea", Senha = "123456" },
            };
        }
    }
}