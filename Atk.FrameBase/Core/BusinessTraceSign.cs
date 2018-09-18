using System;

namespace Atk.DataPortal.Core
{
    /// <summary>
    /// 类访问路径标识工具类
    /// </summary>
    internal static class BusinessTraceSign
    {

        public static void TraceSignWcf(this Object obj)
        {
            if (obj is IBusinessTrace && obj is IBusinessBaseContext)
            {
                var o = (IBusinessBaseContext)obj;
                (obj as IBusinessTrace).AccessPath = o.Context.EndPointName;

            }
        }

        /// <summary>
        /// 为业务类作访问路径标记
        /// </summary>
        /// <param name="obj">业务类</param>
        /// <param name="path">路径</param>
        public static void TraceSignPath(this Object obj, string path)
        {
            if (obj is IBusinessTrace)
            {
                (obj as IBusinessTrace).AccessPath = path;
            }
        }

        /// <summary>
        /// 标记访问地址
        /// </summary>
        /// <param name="obj">业务类</param>
        /// <param name="address">地址</param>
        public static void TraceSignAddress(this Object obj, string address)
        {
            if (obj is IBusinessTrace)
            {
                (obj as IBusinessTrace).AccessAddress = address;
            } 
        }

        /// <summary>
        /// 标记本地地址
        /// </summary>
        /// <param name="obj">业务类</param>
        public static void TraceSignLoacl(this Object obj)
        {
            if (obj is IBusinessTrace)
            {
                (obj as IBusinessTrace).AccessPath = "Local-out";
                (obj as IBusinessTrace).AccessAddress = "Local Access";
            }
        }
    }
}
