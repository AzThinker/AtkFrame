//-----------------------------------------------------------------------
// <copyright file="WcfResponse.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: http://www.lhotka.net/cslanet/
// </copyright>
// <summary>Response message for returning</summary>
//-----------------------------------------------------------------------
using System;
using System.Runtime.Serialization;

namespace Atk.DataPortal.Server.Hosts.WcfChannel
{
    /// <summary>
    /// 数据门调用时返回的响应消息结果
    /// </summary>
    [DataContract]
    public class WcfResponse
    {
        [DataMember]
        private object _result;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="result">返回的对象</param>
        public WcfResponse(object result)
        {
            _result = result;
        }

        /// <summary>
        /// 服务端调用的结果，业务对象或异常返回
        /// </summary>
        public object Result
        {
            get { return _result; }
            set { _result = value; }
        }
    }
}