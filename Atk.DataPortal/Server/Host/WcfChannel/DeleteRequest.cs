using Atk.DataPortal.Core;
//-----------------------------------------------------------------------
// <copyright file="DeleteRequest.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: http://www.lhotka.net/cslanet/
// </copyright>
// <summary>Request message for deleting</summary>
//-----------------------------------------------------------------------
using System;
using System.Runtime.Serialization;
 

namespace Atk.DataPortal.Server.Hosts.WcfChannel
{
    /// <summary>
    /// 删除业务对象请求消息
    /// </summary>
    [DataContract]
    public class DeleteRequest
    {
        [DataMember]
        private Type _objectType;
        [DataMember]
        private object _criteria;
        [DataMember]
        private DataPortalContext _context;

        /// <summary>
        /// 删除业务实例
        /// </summary>
        /// <param name="objectType">删除类型</param>
        /// <param name="criteria">业务参数</param>
        /// <param name="context">客户端传入的数据上下文</param>
        public DeleteRequest(Type objectType, object criteria, DataPortalContext context)
        {
            _objectType = objectType;
            _criteria = criteria;
            _context = context;
        }

        /// <summary>
        /// 删除类型
        /// </summary>
        public Type ObjectType
        {
            get { return _objectType; }
            set { _objectType = value; }
        }

        /// <summary>
        /// 参数实例
        /// </summary>
        public object Criteria
        {
            get { return _criteria; }
            set { _criteria = value; }
        }

        /// <summary>
        /// 客户端传入的数据上下文
        /// </summary>
        public DataPortalContext Context
        {
            get { return _context; }
            set { _context = value; }
        }
    }
}