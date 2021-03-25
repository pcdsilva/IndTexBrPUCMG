using Gestao_de_normas.DTOs;
using System.Collections.Generic;

namespace Gestao_de_normas.Base
{
    public class BaseUsuarios
    {
        public static IEnumerable<Usuario> Usuarios()
        {
            return new List<Usuario>
            {
                new Usuario { Nome = "murilo@sigo.com.br", Senha = "123456", Perfil = new string[] { Perfil.Admin} },
                new Usuario { Nome = "paulo@sigo.com.br", Senha = "123456" , Perfil = new string[] { Perfil.Admin} },
                new Usuario { Nome = "andrea@sigo.com.br", Senha = "123456", Perfil = new string[] { Perfil.User } }
            };
        }
    }

    public class Perfil
    {
        public const string Admin = "Administrador";
        public const string User = "Usuario";
    }
}