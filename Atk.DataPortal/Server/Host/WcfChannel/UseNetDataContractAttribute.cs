//-----------------------------------------------------------------------
// <copyright file="UseNetDataContractAttribute.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: http://www.lhotka.net/cslanet/
// </copyright>
// <summary>Specify that WCF should serialize objects in a .NET</summary>
//-----------------------------------------------------------------------
using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace Atk.DataPortal.Server.Hosts.WcfChannel
{

    /// <summary>
    /// WCFӦ��ָ�����л�����.NET�ض��ķ�ʽ�Ա��ָ��Ӷ������ú�ӳ���ܹ������л�����ͬ���͵�ԭ����
    /// </summary>
    public class UseNetDataContractAttribute : Attribute, IOperationBehavior
    {
        #region IOperationBehavior ��Ա

        /// <summary>
        /// û��ʵ��
        /// </summary>
        /// <param name="description">û��ʵ��</param>
        /// <param name="parameters">û��ʵ��</param>
        public void AddBindingParameters(OperationDescription description, BindingParameterCollection parameters)
        {
        }

        /// <summary>
        /// Ϊ�ͻ���������Ϊ����һ��NetDataContractSerializer
        /// </summary>
        /// <param name="description">��������</param>
        /// <param name="proxy">�ͻ��˲�������</param>
        public void ApplyClientBehavior(OperationDescription description, System.ServiceModel.Dispatcher.ClientOperation proxy)
        {
            ReplaceDataContractSerializerOperationBehavior(description);
        }

        /// <summary>
        /// Ϊ�ͻ���������Ϊ����һ��NetDataContractSerializer
        /// </summary>
        /// <param name="description">��������</param>
        /// <param name="dispatch">��������ַ���</param>
        public void ApplyDispatchBehavior(OperationDescription description, System.ServiceModel.Dispatcher.DispatchOperation dispatch)
        {
            ReplaceDataContractSerializerOperationBehavior(description);
        }

        /// <summary>
        /// δʵ��
        /// </summary>
        /// <param name="description">δʵ��</param>
        public void Validate(OperationDescription description)
        {
        }

        #endregion

        private static void ReplaceDataContractSerializerOperationBehavior(OperationDescription description)
        {
            DataContractSerializerOperationBehavior dcsOperationBehavior = description.Behaviors.Find<DataContractSerializerOperationBehavior>();

            if (dcsOperationBehavior != null)
            {
                description.Behaviors.Remove(dcsOperationBehavior);
                description.Behaviors.Add(new NetDataContractOperationBehavior(description));
            }
        }
    }
}