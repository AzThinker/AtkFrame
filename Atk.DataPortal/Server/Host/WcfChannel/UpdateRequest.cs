using Atk.DataPortal.Core;
//-----------------------------------------------------------------------
// <copyright file="UpdateRequest.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: http://www.lhotka.net/cslanet/
// </copyright>
// <summary>Request message for updating</summary>
//-----------------------------------------------------------------------
using System;
using System.Runtime.Serialization;
 

namespace Atk.DataPortal.Server.Hosts.WcfChannel
{
    /// <summary>
    /// 更新的务对象请求
    /// </summary>
    [DataContract]
    public class UpdateRequest
    {

        [DataMember]
        private object _object;

        /// <summary>
        /// 更新业务实例
        /// </summary>
        /// <param name="obj">更新实例对象</param>
        public UpdateRequest(object obj)
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