using Natillera2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Web;

namespace Natillera2.Clases
{
    public class clsEvento
    {
        private DbNatilleraEntities1 dbevento = new DbNatilleraEntities1();
        public Evento evento { get; set; } = new Evento();
        public string Insertar()
        {
            try
            {
                dbevento.Eventos.Add(evento);
                dbevento.SaveChanges();
                return "Se ingresó el evento " + evento.NombreEvento + " a la base de datos.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Actualizar()
        {
            try
            {
                Evento even = ConsultarXId(evento.idEventos);
                if (even == null)
                {
                    return "El evento no existe";
                }
                dbevento.Eventos.AddOrUpdate(evento);
                dbevento.SaveChanges();
                return "Se actualizó el evento con id #" + evento.idEventos + " correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public Evento ConsultarXId(int id)
        {
            Evento even = dbevento.Eventos.FirstOrDefault(e => e.idEventos == id);
            return even;
        }

        public List<Evento> ConsultarXTipo(string tipoEvento)
        {
            return dbevento.Eventos
                .Where(e => e.TipoEvento == tipoEvento)
                .OrderBy(e => e.NombreEvento)
                .ToList();
        }

        public List<Evento> ConsultarXNombre(string Nombre_Evento)
        {
            return dbevento.Eventos
                .Where(e => e.NombreEvento == Nombre_Evento)
                .OrderBy(e => e.NombreEvento)
                .ToList();
        }


        public List<Evento> ConsultarXFecha(DateTime fecha)
        {
            return dbevento.Eventos
                .Where(e => e.FechaEvento == fecha)
                .OrderBy(e => e.NombreEvento)
                .ToList();
        }

        public List<Evento> ConsultarTodos()
        {
            return dbevento.Eventos
                .OrderBy(c => c.NombreEvento)
                .ToList();
        }

        public string Eliminar(int id)
        {
            try
            {
                Evento even = ConsultarXId(id);
                if (even == null)
                {
                    return "El evento no existe";
                }
                dbevento.Eventos.Remove(even);
                dbevento.SaveChanges();
                return "Se eliminó el evento " + even.NombreEvento + " correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}