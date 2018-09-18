using Atk.DataPortal.Core;
using Autofac;
using System;


namespace Atk.DataPortal
{
    /// <summary>
    /// 客户端方法调用上下文，WCF服务上下文
    /// 是autoface操作的实际类
    /// 此类不会从WCF客户端传入服务端
    /// 而是由WCF服务来构造或在非WCF中由MVC构造
    /// </summary>
    public class WorkContextImplementation : DataPortalWorkContext
    {
        /// <summary>
        /// autofac组件上下文
        /// </summary>
        readonly IComponentContext _componentContext;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="componentContext">autofac组件上下文</param>
        public WorkContextImplementation(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        /// <summary>
        /// IOC反转
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>返回结果</returns>
        public override T Resolve<T>()
        {

            return _componentContext.Resolve<T>();
        }

        /// <summary>
        /// IOC反转
        /// </summary>
        /// <param name="objtype">要反转的类型</param>
        /// <returns>类型实例</returns>
        public override object Resolve(Type objtype)
        {

            return _componentContext.Resolve(objtype);
        }

        /// <summary>
        /// IOC反转
        /// </summary>
        /// <typeparam name="T">要反转的类型</typeparam>
        /// <param name="service">反转后实例</param>
        /// <returns>正确反转时为真</returns>
        public override bool TryResolve<T>(out T service)
        {
            return _componentContext.TryResolve(out service);
        }
    }
}
