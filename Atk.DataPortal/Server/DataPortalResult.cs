using System;

namespace Atk.DataPortal.Server
{
    /// <summary>
    /// WCF返回结果包装类
    /// </summary>
    [Serializable]
    public class DataPortalResult
    {
        /// <summary>
        /// 从服务端返回的业务对象
        /// </summary>
        public object ReturnObject { get; private set; }





        /// <summary>
        /// 构造方法
        /// </summary>
        public DataPortalResult()
        {

        }

        /// <summary>
        /// 操作结果
        /// </summary>
        public OperateState State { get; private set; }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="returnObject">只返回业务对象的部分结果</param>
        public DataPortalResult(object returnObject)
        {
            ReturnObject = returnObject;

        }

        /// <summary>
        /// 数据门结果
        /// </summary>
        /// <param name="returnObject">返回对象</param>
        /// <param name="state">操作状态</param>
        public DataPortalResult(object returnObject, OperateState state)
        {
            ReturnObject = returnObject;

            State = state;

        }

        /// <summary>
        /// 数据门结果
        /// </summary>
        /// <param name="state">操作状态</param>
        public DataPortalResult(OperateState state)
        {
            State = state;

        }
    }
}
