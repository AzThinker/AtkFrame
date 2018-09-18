﻿using Atk.DataPortal.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Atk.DataPortal.Server.Hosts.WcfChannel
{

    /// <summary>
    /// 获取业务对象请求
    /// </summary>
    [DataContract]
    public class BatchSaveRequest
    {
        [DataMember]
        private Type _objectType;
        [DataMember]
        private object _criteria;
        [DataMember]
        private DataPortalContext _context;

        /// <summary>
        /// 获取业务实例
        /// </summary>
        /// <param name="objectType">获取类型</param>
        /// <param name="criteria">业务参数</param>
        /// <param name="context">客户端传入的数据上下文</param>
        public BatchSaveRequest(Type objectType, object criteria, DataPortalContext context)
        {
            _objectType = objectType;
            _criteria = criteria;
            _context = context;
        }

        /// <summary>
        /// 获取类型
        /// </summary>
        public Type ObjectType
        {
            get { return _objectType; }
            set { _objectType = value; }
        }

        /// <summary>
        /// 业务参数
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
