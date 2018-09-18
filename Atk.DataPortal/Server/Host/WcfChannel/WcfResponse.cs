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
    /// �����ŵ���ʱ���ص���Ӧ��Ϣ���
    /// </summary>
    [DataContract]
    public class WcfResponse
    {
        [DataMember]
        private object _result;

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="result">���صĶ���</param>
        public WcfResponse(object result)
        {
            _result = result;
        }

        /// <summary>
        /// ����˵��õĽ����ҵ�������쳣����
        /// </summary>
        public object Result
        {
            get { return _result; }
            set { _result = value; }
        }
    }
}