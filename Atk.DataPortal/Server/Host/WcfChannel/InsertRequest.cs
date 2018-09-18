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
    /// �����µ�ҵ���������
    /// </summary>
    [DataContract]
    public class InsertRequest
    {
        [DataMember]
        private object _object;

        /// <summary>
        /// �����µ�ҵ��ʵ��
        /// </summary>
        /// <param name="obj">��������</param>
        public InsertRequest(object obj)
        {
            _object = obj;
        }


        /// <summary>
        /// ����ʵ������
        /// </summary>
        public object Object
        {
            get { return _object; }
            set { _object = value; }
        }

    }
}