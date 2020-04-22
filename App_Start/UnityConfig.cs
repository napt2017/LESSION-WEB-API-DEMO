using Unity;
using Unity.WebApi;
using System.Web.Http;

using LESSION_WEB_API_DEMO.DataAccess;
using LESSION_WEB_API_DEMO.Repositories;
using LESSION_WEB_API_DEMO.Models;

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
            container.RegisterType<IManufacturerRepository, ManufacturerRepository>();
            container.RegisterType<IRoleRepository, RoleRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<BookStoreDatabaseSettings>();
            container.RegisterType<IBookRepository, BookRepository>();
            container.RegisterSingleton<ExternalApiInfo>();
            container.RegisterType<ISlideRepository, SlideRepository>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}