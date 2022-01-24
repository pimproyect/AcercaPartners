using PedidosCoches.Negocio.Facades;
using PedidosCoches.Negocio.Implements;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace PedidosCoches
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IRepositorioPedidos, RepositorioPedidos>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}