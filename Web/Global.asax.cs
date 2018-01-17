using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using System.Web.Http;
using Unity.RegistrationByConvention;
using Web.ViewModel;
using Web.Infra;
using AutoMapper;

namespace Web
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            RegisterMappers();
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_PostAuthorizeRequest()
        {
            HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required);
        }

        private const string ROOT_DOCUMENT = "~/app/index.html";
        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            string url = Request.Url.LocalPath;
            if (url.Contains("api"))
                return;
            if (url.ToLower() == "/rd")
                return;
            if (url.ToLower().Contains("routedebugger"))
                return;
            if (url.ToLower().Contains("openid"))
                return;
            if (!System.IO.File.Exists(Context.Server.MapPath(url)))
                Context.RewritePath(ROOT_DOCUMENT);
        }
        private void RegisterMappers()
        {
            IEnumerable<Type> viewModels =
                AllClasses.FromLoadedAssemblies()
                    .Where(x => x.Namespace != null && (x.Namespace.StartsWith("Web.ViewModel"))).ToList();
            foreach (Type viewModel in viewModels)
            {

                var methodInfo = viewModel.GetMethod("CreateMappings");
                if (methodInfo != null)
                {
                    var name = viewModel.BaseType.Name;
                    if (name == "BaseIntViewModel")
                    {
                        BaseIntViewModel instance = (BaseIntViewModel)Activator.CreateInstance(viewModel);
                        instance.CreateMappings();
                    }


                }
                else
                {
                    var referenceModel =
                        viewModel.GetCustomAttributes(typeof(ReferenceModelAttribute), false).FirstOrDefault() as
                            ReferenceModelAttribute;
                    if (referenceModel != null)
                    {
                        var destinationType = referenceModel.ReferenceModel;
                        Mapper.CreateMap(destinationType, viewModel);
                        Mapper.CreateMap(viewModel, destinationType);
                    }
                }

            }
        }
    }
}