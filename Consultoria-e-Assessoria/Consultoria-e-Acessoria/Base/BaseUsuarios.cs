using Consultoria_e_Assessoria.DTOs;
using System.Collections.Generic;

namespace Consultoria_e_Assessoria.Base
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