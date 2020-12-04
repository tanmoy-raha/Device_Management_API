using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DeviceMgmt.Core;
using DeviceMgmt.Model;
using DeviceMgmt.Service;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;


namespace DeviceMgmt.Common
{
    /// <summary>
    /// ContainerSetup class is a Inversion of Control
    /// Contains all methods and Configuration
    /// </summary>
    public static class ContainerSetup
    {
        /// <summary>
        /// Setup is used for Resolve Dependency Injection
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <param name="configuration">IConfiguration</param>
        public static void Setup(IServiceCollection services, IConfiguration configuration)
        {
            ResolveDependencyInjectionServices(services);
            ResolveDependencyInjectionCore(services);
            //ResolveDependencyInjectionModel(services);   
            ConfigureAuth(services);           
        }

        private static void ConfigureAuth(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();//Support only Singleton
            
        }

        
        private static void ResolveDependencyInjectionCore(IServiceCollection services)
        {
            var exampleProcessorType = typeof(CoreFactory);
            var types = (from t in exampleProcessorType.GetTypeInfo().Assembly.GetTypes()
                         where t.Namespace == exampleProcessorType.Namespace
                               && t.GetTypeInfo().IsClass
                               && t.GetTypeInfo().GetCustomAttribute<CompilerGeneratedAttribute>() == null
                         select t).ToArray();

            foreach (var type in types)
            {
                var interfaceQ = type.GetTypeInfo().GetInterfaces().First();
                services.AddScoped(interfaceQ, type);
            }

        }

        private static void ResolveDependencyInjectionServices(IServiceCollection services)
        {
            var exampleProcessorType = typeof(ServicesFactory);
            var types = (from t in exampleProcessorType.GetTypeInfo().Assembly.GetTypes()
                         where t.Namespace == exampleProcessorType.Namespace
                               && t.GetTypeInfo().IsClass
                               && t.GetTypeInfo().GetCustomAttribute<CompilerGeneratedAttribute>() == null
                         select t).ToArray();

            foreach (var type in types)
            {
                var interfaceQ = type.GetTypeInfo().GetInterfaces().FirstOrDefault();
                services.AddScoped(interfaceQ, type);
            }
        }
        //private static void ResolveDependencyInjectionModel(IServiceCollection services)
        //{
        //    var exampleProcessorType = typeof(ModelFactory);
        //    var types = (from t in exampleProcessorType.GetTypeInfo().Assembly.GetTypes()
        //                 where t.Namespace == exampleProcessorType.Namespace
        //                       && t.GetTypeInfo().IsClass
        //                       && t.GetTypeInfo().GetCustomAttribute<CompilerGeneratedAttribute>() == null
        //                 select t).ToArray();

        //    foreach (var type in types)
        //    {
        //        var interfaceQ = type.GetTypeInfo().GetInterfaces().FirstOrDefault();
        //        services.AddScoped(interfaceQ, type);
        //    }
        //}

    }
}
