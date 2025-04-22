using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Natillera2.Models
{
    public class Login // Recibe el usuario y la clave
    {
        public string Usuario { get; set; }
        public string Clave { get; set; }
    }
    public class LoginRespuesta // Recibe el resultado de la autenticación
    {
        public string Usuario { get; set; }
        public string Perfil { get; set; }
        public string PaginaInicio { get; set; }
        public bool Autenticado { get; set; }
        public string Token { get; set; }
        public string Mensaje { get; set; } // Mensaje para manejar los errores
    }
}