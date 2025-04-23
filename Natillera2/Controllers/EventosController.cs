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
    [RoutePrefix("api/Eventos")]
    public class EventosController : ApiController
    {
        //DELETE: Se utiliza para eliminar información en la base de datos
        [HttpGet] //Es el servicio que se va a exponer: GET, POST, PUT, DELETE
        [Route("ConsultarTodos")] //Es el nombre de la funcionalidad que se va a ejecutar
        public List<Evento> ConsultarTodos()
        {
            //Se crea una instancia de la clase clsEvento
            clsEvento Evento = new clsEvento();
            //Se invoca el método ConsultarTodos() de la clase clsEvento
            return Evento.ConsultarTodos();
        }

        [HttpGet] 
        [Route("ConsultarXTipo")] 
        public List<Evento> ConsultarXTipo(string tipoEvento)
        {
            //Se crea una instancia de la clase clsEvento
            clsEvento Evento = new clsEvento();
            //Se invoca el método ConsultarTodos() de la clase clsEvento
            return Evento.ConsultarXTipo(tipoEvento);
        }

        [HttpGet]
        [Route("ConsultarXNombre")]
        public List<Evento> ConsultarXNombre(string nombreEvento)
        {
            //Se crea una instancia de la clase clsEvento
            clsEvento Evento = new clsEvento();
            //Se invoca el método ConsultarXNombre() de la clase clsEvento
            return Evento.ConsultarXNombre(nombreEvento);
        }

        [HttpGet]
        [Route("ConsultarXFecha")]
        public List<Evento> ConsultarXFecha (DateTime fechaEvento)
        {
            //Se crea una instancia de la clase clsEvento
            clsEvento Evento = new clsEvento();
            //Se invoca el método ConsultarXFecha() de la clase clsEvento
            return Evento.ConsultarXFecha(fechaEvento);
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public Evento ConsultarXId(int idEvento)
        {
            //Se crea una instancia de la clase clsEvento
            clsEvento Evento = new clsEvento();
            //Se invoca el método ConsultarXId() de la clase clsEvento
            return Evento.ConsultarXId(idEvento);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Evento evento)
        {
            //Se crea una instancia de la clase clsEvento
            clsEvento eve = new clsEvento();
            //Se pasa la propieadad Evento al objeto de la clase clsEvento
            eve.evento = evento;
            //Se invoca el método insertar
            return eve.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Evento evento)
        {
            clsEvento even = new clsEvento();
            even.evento = evento;
            return even.Actualizar();
        }

        [HttpDelete]
        [Route("EliminarXId")]
        public string EliminarXId(int idEventos)
        {
            clsEvento Evento = new clsEvento();
            return Evento.Eliminar(idEventos);
        }
    }
}