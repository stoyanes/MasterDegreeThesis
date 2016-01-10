using Microsoft.Practices.Unity;
using Server.Business.Configs;
using System.Web.Http;
using Unity.WebApi;

namespace Server.Services
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = UnityDIResolver.DefaultContainer;
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}