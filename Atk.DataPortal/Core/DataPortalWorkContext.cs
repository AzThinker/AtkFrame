using System;

namespace Atk.DataPortal.Core
{
    /// <summary>
    /// Autoface工作上下文，用于类型反转
    /// 主要应用于WCF访问链路中
    /// </summary>
    [Serializable]
    public abstract class DataPortalWorkContext
    {
        /// <summary>
        /// IOC反转
        /// </summary>
        /// <typeparam name="T">反转类</typeparam>
        /// <returns>返转后实例</returns>
        public abstract T Resolve<T>();

        /// <summary>
        /// IOC反转
        /// </summary>
        /// <typeparam name="T">反转类</typeparam>
        /// <param name="service">输出实例</param>
        /// <returns>成功时为真</returns>
        public abstract bool TryResolve<T>(out T service);

        /// <summary>
        /// IOC反转
        /// </summary>
        /// <param name="objtype">要反转的类型</param>
        /// <returns>类型实例</returns>
        public abstract object Resolve(Type objtype);

 



    }
}
