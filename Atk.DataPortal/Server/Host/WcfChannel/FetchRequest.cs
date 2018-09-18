using Atk.DataPortal.Core;
//-----------------------------------------------------------------------
// <copyright file="FetchRequest.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: http://www.lhotka.net/cslanet/
// </copyright>
// <summary>Request message for retrieving</summary>
//-----------------------------------------------------------------------
using System;
using System.Runtime.Serialization;
 

namespace Atk.DataPortal.Server.Hosts.WcfChannel
{
    /// <summary>
    /// ��ȡҵ���������
    /// </summary>
    [DataContract]
    public class FetchRequest
    {
        [DataMember]
        private Type _objectType;
        [DataMember]
        private object _criteria;
        [DataMember]
        private DataPortalContext _context;

        /// <summary>
        /// ��ȡҵ��ʵ��
        /// </summary>
        /// <param name="objectType">��ȡ����</param>
        /// <param name="criteria">ҵ�����</param>
        /// <param name="context">�ͻ��˴��������������</param>
        public FetchRequest(Type objectType, object criteria, DataPortalContext context)
        {
            _objectType = objectType;
            _criteria = criteria;
            _context = context;
        }

        /// <summary>
        /// ��ȡ����
        /// </summary>
        public Type ObjectType
        {
            get { return _objectType; }
            set { _objectType = value; }
        }

        /// <summary>
        /// ҵ�����
        /// </summary>
        public object Criteria
        {
            get { return _criteria; }
            set { _criteria = value; }
        }

        /// <summary>
        /// �ͻ��˴��������������
        /// </summary>
        public DataPortalContext Context
        {
            get { return _context; }
            set { _context = value; }
        }
    }
}