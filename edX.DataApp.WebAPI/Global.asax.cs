using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity.WebApi;
using edX.DataApp.WebAPI.Models;
using System.Data.Entity;
using System.Web.Http.OData.Builder;

namespace edX.DataApp.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            // [4.1.1] You can now use any types registered in your Unity container 
            // as a constructor parameter for a Web API controller --> ProductsController.cs
            GlobalConfiguration.Configure(config =>
            {
                UnityContainer container = new UnityContainer();
                container.RegisterType<ContosoContext>();
                config.DependencyResolver = new UnityDependencyResolver(container);
            }
            );

            

            // [4.1.2] A Database Initializer should be configured once in your application 
            // before any instances of the context class is created ( 1 variant ) --> ContosoContext
            #region DB Initializer

            /*
            /// This initializer is the default initializer used by Entity Framework if no other initializer is specified.
            Database.SetInitializer<ContosoContext>(new CreateDatabaseIfNotExists<ContosoContext>());

            /// This initialzer always drops and re-creates the database everytime your application is started. 
            Database.SetInitializer<ContosoContext>(new DropCreateDatabaseAlways<ContosoContext>());

            /// You would like the database to automatically update to match your model classes as you write code.
            Database.SetInitializer<ContosoContext>(new DropCreateDatabaseIfModelChanges<ContosoContext>());
            */

            #endregion
        }
    }
}
