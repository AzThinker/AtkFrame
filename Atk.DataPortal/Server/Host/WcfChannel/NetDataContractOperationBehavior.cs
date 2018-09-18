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
    /// 为NetDataContractSerializer重载DataContract序列化行为
    /// </summary>
    public class NetDataContractOperationBehavior : DataContractSerializerOperationBehavior
    {
        #region 构造

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="operation">操作描述</param>
        public NetDataContractOperationBehavior(OperationDescription operation)
            : base(operation)
        {
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="operation">操作描述</param>
        /// <param name="dataContractFormatAttribute">数据契约特性对象</param>
        public NetDataContractOperationBehavior(OperationDescription operation, DataContractFormatAttribute dataContractFormatAttribute)
            : base(operation, dataContractFormatAttribute)
        {
        }

        #endregion

        #region 重载方法

        ///// <summary>
        ///// 重截CreateSerializer返回XmlObjectSerializer，提供可保存业务对象的引用能力
        ///// </summary>
        /// <summary>
        /// 创建类的一个实例，该类从序列化和反序列化过程的 XmlObjectSerializer 中继承。
        /// 重截CreateSerializer返回XmlObjectSerializer，提供可保存业务对象的引用能力
        /// </summary>
        /// <param name="type">要为其创建序列化程序的 Type</param>
        /// <param name="name">生成类型的名称</param>
        /// <param name="ns">生成类型的命名空间</param>
        /// <param name="knownTypes">包含已知类型的 Type 的 IList</param>
        /// <returns>继承自 XmlObjectSerializer 类的一个类的实例</returns>
        public override XmlObjectSerializer CreateSerializer(Type type, string name, string ns,
            IList<Type> knownTypes)
        {
            return new NetDataContractSerializer(name, ns);
        }

        /// <summary>
        /// 创建类的一个实例，该类从序列化和反序列化过程
        /// （其 XmlDictionaryString 包含命名空间）的 XmlObjectSerializer 中继承。
        /// 重截CreateSerializer返回XmlObjectSerializer，提供可保存业务对象的引用能力
        /// </summary>
        /// <param name="type">要序列化或反序列化的类型</param>
        /// <param name="name">序列化类型的名称</param>
        /// <param name="ns">包含序列化类型的命名空间的 XmlDictionaryString</param>
        /// <param name="knownTypes">包含已知类型的 Type 的 IList</param>
        /// <returns>继承自 XmlObjectSerializer 类的一个类的实例</returns>
        public override XmlObjectSerializer CreateSerializer(Type type, XmlDictionaryString name,
            XmlDictionaryString ns, IList<Type> knownTypes)
        {
            return new NetDataContractSerializer(name, ns);
        }

        #endregion
    }
}