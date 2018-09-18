using Atk.DataPortal.Core;
//-----------------------------------------------------------------------
// <copyright file="CreateRequest.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: http://www.lhotka.net/cslanet/
// </copyright>
// <summary>Request message for creating</summary>
//-----------------------------------------------------------------------
using System;
using System.Runtime.Serialization;


namespace Atk.DataPortal.Server.Hosts.WcfChannel
{
    /// <summary>
    /// 创建新的业务对象请求
    /// </summary>
    [DataContract]
    public class InsertRequest
    {
        [DataMember]
        private object _object;

        /// <summary>
        /// 创建新的业务实例
        /// </summary>
        /// <param name="obj">创建类型</param>
        public InsertRequest(object obj)
        {
            _object = obj;
        }


        /// <summary>
        /// 更新实例对象
        /// </summary>
        public object Object
        {
            get { return _object; }
            set { _object = value; }
        }

    }
}