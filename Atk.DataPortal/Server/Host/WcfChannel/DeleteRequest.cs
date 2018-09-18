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
    /// ɾ��ҵ�����������Ϣ
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
        /// ɾ��ҵ��ʵ��
        /// </summary>
        /// <param name="objectType">ɾ������</param>
        /// <param name="criteria">ҵ�����</param>
        /// <param name="context">�ͻ��˴��������������</param>
        public DeleteRequest(Type objectType, object criteria, DataPortalContext context)
        {
            _objectType = objectType;
            _criteria = criteria;
            _context = context;
        }

        /// <summary>
        /// ɾ������
        /// </summary>
        public Type ObjectType
        {
            get { return _objectType; }
            set { _objectType = value; }
        }

        /// <summary>
        /// ����ʵ��
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