using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace TuiFranceTest.Bal
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}