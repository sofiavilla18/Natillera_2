﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Natillera2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //// Web API configuration and services
            ////Habilitar el esquema de autenticación, para la validación del token
            config.MessageHandlers.Add(new TokenValidationHandler());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
