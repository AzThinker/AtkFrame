using System;
using System.Collections.Generic;
using System.Reflection;

namespace Atk.WebCore.Infrastructure
{
    /// <summary>
    /// 实现此接口的类提供有关反转各种服务的类型的信息。
    /// </summary>
    public interface ITypeFinder
    {
        /// <summary>
        /// 获取程序集列表
        /// </summary>
        /// <returns>程序集列表</returns>
        IList<Assembly> GetAssemblies();

        /// <summary>
        /// 获取类型列表
        /// </summary>
        /// <param name="assignTypeFrom">类型</param>
        /// <param name="onlyConcreteClasses">有构造方法</param>
        /// <returns>类型列表</returns>
        IEnumerable<Type> FindClassesOfType(Type assignTypeFrom, bool onlyConcreteClasses = true);

        /// <summary>
        /// 在指定程序集中发现类型
        /// </summary>
        /// <param name="assignTypeFrom">类型</param>
        /// <param name="assemblies">程序集</param>
        /// <param name="onlyConcreteClasses">有构造方法</param>
        /// <returns>类型列表</returns>
        IEnumerable<Type> FindClassesOfType(Type assignTypeFrom, IEnumerable<Assembly> assemblies, bool onlyConcreteClasses = true);

        /// <summary>
        /// 发现类型
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="onlyConcreteClasses">有构造方法</param>
        /// <returns>类型列表</returns>
        IEnumerable<Type> FindClassesOfType<T>(bool onlyConcreteClasses = true);

        /// <summary>
        /// 在指定程序集中发现类型
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="assemblies">程序集</param>
        /// <param name="onlyConcreteClasses">有构造方法</param>
        /// <returns>类型列表</returns>
        IEnumerable<Type> FindClassesOfType<T>(IEnumerable<Assembly> assemblies, bool onlyConcreteClasses = true);
    }
}
