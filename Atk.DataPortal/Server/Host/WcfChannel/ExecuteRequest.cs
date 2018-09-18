using Atk.DataPortal.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Atk.DataPortal.Server.Hosts.WcfChannel
{
    /// <summary>
    /// 执行类请求参数
    /// </summary>
    [DataContract]
    public class ExecuteRequest
    {
        [DataMember]
        private object _object;


        /// <summary>
        /// 创建新的业务实例
        /// </summary>
        /// <param name="obj">创建类型</param>
        public ExecuteRequest(object obj)
        {
            _object = obj;
        }

        /// <summary>
        /// 要创建的业务对象类型
        /// </summary>
        public object Object
        {
            get { return _object; }
            set { _object = value; }
        }



    }
}
