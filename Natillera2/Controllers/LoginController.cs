using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Natillera2.Models;
using Natillera2.Clases;

namespace Natillera2.Controllers
{
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("Ingresar")]
        public IQueryable<LoginRespuesta> Ingresar(Login login)
        {
            //Se crea una instancia de la clase clsEmpleado
            clsLogin _Login = new clsLogin();
            //Se pasa la propieadad empleado al objeto de la clases clsEmpleado
            _Login.login = login;
            //Se invoca el método insertar
            return _Login.Ingresar();
        }
    }
}