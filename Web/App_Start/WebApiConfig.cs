using Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Unity;
using Unity.Injection;
using Unity.RegistrationByConvention;
using Web.App_Start;

namespace Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            string cs = ConfigurationManager.ConnectionStrings["InsuranceEntities"].ConnectionString;
            var insuranceEntities = new InsuranceEntities(cs);
            var container = new UnityContainer();
            container.RegisterType<InsuranceEntities>(new InjectionFactory(c => insuranceEntities));

            var enumerable = AllClasses.FromLoadedAssemblies().Where(x =>
                x.Namespace != null && (x.Namespace.Contains("Service") ||
                                        x.Namespace.Contains("Repository")));
            container.RegisterTypes(
               //AllClasses.FromAssemblies(),
               enumerable,
               WithMappings.FromMatchingInterface,
               WithName.Default,
               WithLifetime.PerResolve
            );
            config.DependencyResolver = new UnityResolver(container);
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
