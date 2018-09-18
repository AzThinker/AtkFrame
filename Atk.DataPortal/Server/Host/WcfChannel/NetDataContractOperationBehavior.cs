//-----------------------------------------------------------------------
// <copyright file="NetDataContractOperationBehavior.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: http://www.lhotka.net/cslanet/
// </copyright>
// <summary>Override the DataContract serialization behavior to</summary>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Xml;
using System.ServiceModel.Description;

namespace Atk.DataPortal.Server.Hosts.WcfChannel
{
    /// <summary>
    /// ΪNetDataContractSerializer����DataContract���л���Ϊ
    /// </summary>
    public class NetDataContractOperationBehavior : DataContractSerializerOperationBehavior
    {
        #region ����

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="operation">��������</param>
        public NetDataContractOperationBehavior(OperationDescription operation)
            : base(operation)
        {
        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="operation">��������</param>
        /// <param name="dataContractFormatAttribute">������Լ���Զ���</param>
        public NetDataContractOperationBehavior(OperationDescription operation, DataContractFormatAttribute dataContractFormatAttribute)
            : base(operation, dataContractFormatAttribute)
        {
        }

        #endregion

        #region ���ط���

        ///// <summary>
        ///// �ؽ�CreateSerializer����XmlObjectSerializer���ṩ�ɱ���ҵ��������������
        ///// </summary>
        /// <summary>
        /// �������һ��ʵ������������л��ͷ����л����̵� XmlObjectSerializer �м̳С�
        /// �ؽ�CreateSerializer����XmlObjectSerializer���ṩ�ɱ���ҵ��������������
        /// </summary>
        /// <param name="type">ҪΪ�䴴�����л������ Type</param>
        /// <param name="name">�������͵�����</param>
        /// <param name="ns">�������͵������ռ�</param>
        /// <param name="knownTypes">������֪���͵� Type �� IList</param>
        /// <returns>�̳��� XmlObjectSerializer ���һ�����ʵ��</returns>
        public override XmlObjectSerializer CreateSerializer(Type type, string name, string ns,
            IList<Type> knownTypes)
        {
            return new NetDataContractSerializer(name, ns);
        }

        /// <summary>
        /// �������һ��ʵ������������л��ͷ����л�����
        /// ���� XmlDictionaryString ���������ռ䣩�� XmlObjectSerializer �м̳С�
        /// �ؽ�CreateSerializer����XmlObjectSerializer���ṩ�ɱ���ҵ��������������
        /// </summary>
        /// <param name="type">Ҫ���л������л�������</param>
        /// <param name="name">���л����͵�����</param>
        /// <param name="ns">�������л����͵������ռ�� XmlDictionaryString</param>
        /// <param name="knownTypes">������֪���͵� Type �� IList</param>
        /// <returns>�̳��� XmlObjectSerializer ���һ�����ʵ��</returns>
        public override XmlObjectSerializer CreateSerializer(Type type, XmlDictionaryString name,
            XmlDictionaryString ns, IList<Type> knownTypes)
        {
            return new NetDataContractSerializer(name, ns);
        }

        #endregion
    }
}