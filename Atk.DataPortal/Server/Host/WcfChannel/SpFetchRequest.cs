using Atk.DataPortal.Core;
using System;
using System.Runtime.Serialization;

namespace Atk.DataPortal.Server.Hosts.WcfChannel
{
    /// <summary>
    /// 获取查询类存储过程业务对象请求
    /// </summary>
    [DataContract]
    public class SpFetchRequest
    {

        [DataMember]
        private object _object;


        /// <summary>
        /// 获取业务实例
        /// </summary>
        /// <param name="Object">业务本身作为参数传入</param>
        public SpFetchRequest(object Object)
        {
            _object = Object;
        }

        /// <summary>
        /// 业务类本身
        /// </summary>
        public object Object
        {
            get { return _object; }
            set { _object = value; }
        }

    }
}
