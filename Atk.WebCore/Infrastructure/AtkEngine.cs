using Atk.DataPortal;
using Atk.WebCore.Infrastructure.DependencyManagement;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using Module = Autofac.Module;
namespace Atk.WebCore.Infrastructure
{
    /// <summary>
    /// Engine
    /// </summary>
    public class AtkEngine : IEngine
    {
        #region Properties

        //容器管理器
        private IServiceProvider _serviceProvider { get; set; }

        public virtual IServiceProvider ServiceProvider => _serviceProvider;
        #endregion

        #region Utilities

        protected IServiceProvider GetServiceProvider()
        {
            var accessor = ServiceProvider.GetService<IHttpContextAccessor>();
            var context = accessor.HttpContext;
            return context?.RequestServices ?? ServiceProvider;
        }


        public IServiceProvider ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var typeFinder = new WebAppTypeFinder();
            var startupConfigurations = typeFinder.FindClassesOfType<IAtkStartup>();

            var instances = startupConfigurations
                .Select(startup => (IAtkStartup)Activator.CreateInstance(startup))
                .OrderBy(startup => startup.Order);

            foreach (var instance in instances)
            {
                instance.ConfigureServices(services, configuration);
            }

            RegisterDependencies(services);

            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            return _serviceProvider;
        }

        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            //check for assembly already loaded
            var assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.FullName == args.Name);
            if (assembly != null)
            {
                return assembly;
            }

            //get assembly from TypeFinder
            var tf = new WebAppTypeFinder();// Resolve<ITypeFinder>();
            assembly = tf.GetAssemblies().FirstOrDefault(a => a.FullName == args.Name);
            return assembly;
        }
        /// <summary>
        /// 依赖注入
        /// </summary>
        protected virtual IServiceProvider RegisterDependencies(IServiceCollection services) //FniConfig config
        {
            var builder = new ContainerBuilder();
            var typeFinder = new WebAppTypeFinder();

            builder.RegisterInstance(this).As<IEngine>().SingleInstance();
            builder.RegisterInstance(typeFinder).As<ITypeFinder>().SingleInstance();
            builder.RegisterInstance(new DataSettingsManager()).As<IDataSettingsManager>().SingleInstance();
            var drTypes = typeFinder.FindClassesOfType<IDependencyRegistrar>();
            var drInstances = drTypes.Select(dependencyRegistrar => (IDependencyRegistrar)Activator
                                  .CreateInstance(dependencyRegistrar))
                                  .OrderBy(dependencyRegistrar => dependencyRegistrar.Order); ;


            foreach (var dependencyRegistrar in drInstances)
            {
                dependencyRegistrar.Register(builder, typeFinder);
            }

            var drTypes2 = typeFinder.FindClassesOfType<Module>();
            var drInstances2 = drTypes2.Select(dependencyRegistrar => (Module)Activator
                                   .CreateInstance(dependencyRegistrar));


            foreach (var dependencyRegistrar in drInstances2)
            {
                builder.RegisterModule(dependencyRegistrar);
            }
            // 如果 MVC工程中没有引用 System.ServiceModel则应加入下句，否则基础库不能引用
            // 在Aspnet.core 中 引用System.ServiceModel.Http
            //   builder.RegisterModule(new AutoRegister_Module());
            builder.Populate(services);
            DataSettingsHelper.DatabaseIsInstalled(new DataSettingsManager());
            _serviceProvider = new AutofacServiceProvider(builder.Build());
            return _serviceProvider;
        }

        #endregion

        #region Methods

        /// <summary>
        /// 初始化当前IOC环境
        /// </summary>
        public void Initialize(IServiceCollection services)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var provider = services.BuildServiceProvider();
            var hostingEnvironment = provider.GetRequiredService<IHostingEnvironment>();
            services.AddMvcCore();
        }

        /// <summary>
        /// 依赖反转
        /// </summary>
        /// <typeparam name="T">反转类型</typeparam>
        /// <returns>类型实例</returns>
        public T Resolve<T>() where T : class
        {
            return (T)GetServiceProvider().GetRequiredService(typeof(T));
        }

        /// <summary>
        ///  依赖反转
        /// </summary>
        /// <param name="type">反转类型</param>
        /// <returns>类型实例</returns>
        public object Resolve(Type type)
        {
            return GetServiceProvider().GetRequiredService(type);
        }

        /// <summary>
        /// 依赖反转
        /// </summary>
        /// <typeparam name="T">反转类型</typeparam>
        /// <returns>类型实例</returns>
        public IEnumerable<T> ResolveAll<T>()
        {
            return (IEnumerable<T>)GetServiceProvider().GetServices(typeof(T));
        }

        #endregion


    }
}
