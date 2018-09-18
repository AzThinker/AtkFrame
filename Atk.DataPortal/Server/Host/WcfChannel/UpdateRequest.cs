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
    /// ���µ����������
    /// </summary>
    [DataContract]
    public class UpdateRequest
    {

        [DataMember]
        private object _object;

        /// <summary>
        /// ����ҵ��ʵ��
        /// </summary>
        /// <param name="obj">����ʵ������</param>
        public UpdateRequest(object obj)
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