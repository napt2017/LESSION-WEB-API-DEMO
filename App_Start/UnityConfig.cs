using LESSION_WEB_API_DEMO.DataAccess;
using LESSION_WEB_API_DEMO.Repositories;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace LESSION_WEB_API_DEMO
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            //container.RegisterType<ProductManagementDbContext>();
            container.RegisterSingleton<ProductManagementDbContext>();
            container.RegisterType<IProductRepository, ProductRepository>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}