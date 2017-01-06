﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace _1_WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuration et services API Web

            // Itinéraires de l'API Web
            //config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute(
                     name: "Common_default",
                     routeTemplate: "api/{controller}/{action}/{id}",
                     defaults: new { id = RouteParameter.Optional }
                 );

            config.Routes.MapHttpRoute(
                      name: "CommonApiAction",
                      routeTemplate: "api/{controller}/{action}",
                      defaults: new { id = RouteParameter.Optional }
                  );

            config.Routes.MapHttpRoute(
                   name: "CommonApi",
                   routeTemplate: "api/{controller}",
                   defaults: new { id = RouteParameter.Optional }
               );
        }
    }
}
