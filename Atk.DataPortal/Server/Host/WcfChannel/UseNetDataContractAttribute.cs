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
    /// WCF应该指定序列化对象。.NET特定的方式以保持复杂对象引用和映射能够反序列化到相同类型的原对象。
    /// </summary>
    public class UseNetDataContractAttribute : Attribute, IOperationBehavior
    {
        #region IOperationBehavior 成员

        /// <summary>
        /// 没有实现
        /// </summary>
        /// <param name="description">没有实现</param>
        /// <param name="parameters">没有实现</param>
        public void AddBindingParameters(OperationDescription description, BindingParameterCollection parameters)
        {
        }

        /// <summary>
        /// 为客户端请求行为附加一个NetDataContractSerializer
        /// </summary>
        /// <param name="description">操作描述</param>
        /// <param name="proxy">客户端操作对象</param>
        public void ApplyClientBehavior(OperationDescription description, System.ServiceModel.Dispatcher.ClientOperation proxy)
        {
            ReplaceDataContractSerializerOperationBehavior(description);
        }

        /// <summary>
        /// 为客户端请求行为附加一个NetDataContractSerializer
        /// </summary>
        /// <param name="description">操作描述</param>
        /// <param name="dispatch">操作对象分发器</param>
        public void ApplyDispatchBehavior(OperationDescription description, System.ServiceModel.Dispatcher.DispatchOperation dispatch)
        {
            ReplaceDataContractSerializerOperationBehavior(description);
        }

        /// <summary>
        /// 未实现
        /// </summary>
        /// <param name="description">未实现</param>
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