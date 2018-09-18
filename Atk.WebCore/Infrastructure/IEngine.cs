using System;
using System.Collections.Generic;
using Atk.WebCore.Infrastructure.DependencyManagement;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Atk.WebCore.Infrastructure
{
    /// <summary>
    /// 容器管理者接口
    /// interface.
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// 容器管理者
        /// </summary>
        //ContainerManager ContainerManager { get; }

        /// <summary>
        /// Initialize components and plugins in the nop environment.
        /// </summary>
        void Initialize(IServiceCollection services);

        /// <summary>
        /// 反转类型
        /// </summary>
        /// <typeparam name="T">反转类型</typeparam>
        /// <returns>反转类型实例</returns>
        T Resolve<T>() where T : class;


        IServiceProvider ConfigureServices(IServiceCollection services, IConfiguration configuration);

        /// <summary>
        ///  反转类型
        /// </summary>
        /// <param name="type">反转类型</param>
        /// <returns>反转类型实例</returns>
        object Resolve(Type type);

        /// <summary>
        /// 反转类型
        /// </summary>
        /// <typeparam name="T">反转类型</typeparam>
        /// <returns>反转类型实例</returns>
        IEnumerable<T> ResolveAll<T>();
    }
}
