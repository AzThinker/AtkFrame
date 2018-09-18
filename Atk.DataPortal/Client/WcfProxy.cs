using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atk.DataPortal.Server;
using Atk.DataPortal.Server.Hosts.WcfChannel;
using Atk.DataPortal.Core;

namespace Atk.DataPortal.Client
{
    /// <summary>
    /// WCF客户端
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal sealed class WcfProxy<T>
        where T : IBusinessTrace, IBusinessBaseContext
    {
        private static System.ServiceModel.Channels.Binding _defaultBinding;
        private const int TimeoutInMinutes = 10;
        private static string _defaultEndPoint = "WcfDataPortal";//无配置时的终结点名


        /// <summary>
        /// 获取和设置默认绑定风格
        /// </summary>
        public static System.ServiceModel.Channels.Binding DefaultBinding
        {
            get
            {
                if (_defaultBinding == null)
                {
                    _defaultBinding = new BasicHttpBinding();
                    BasicHttpBinding binding = (BasicHttpBinding)_defaultBinding;
                    binding.MaxBufferSize = int.MaxValue;
                    binding.MaxReceivedMessageSize = int.MaxValue;
                    binding.ReceiveTimeout = TimeSpan.FromMinutes(TimeoutInMinutes);
                    binding.SendTimeout = TimeSpan.FromMinutes(TimeoutInMinutes);
                    binding.OpenTimeout = TimeSpan.FromMinutes(TimeoutInMinutes);
                };
                return _defaultBinding;
            }
            private set { _defaultBinding = value; }
        }

        /// <summary>
        /// 获取和设置服务终结点
        /// </summary>
        public static string DefaultEndPoint
        {
            get { return _defaultEndPoint; }
            private set { _defaultEndPoint = value; }
        }

        /// <summary>
        /// 创建默认的代理服务
        /// values.
        /// </summary>
        public WcfProxy()
        {
            this.Binding = WcfProxy<T>.DefaultBinding;
            this.EndPoint = WcfProxy<T>.DefaultEndPoint;
        }


        /// <summary>
        /// 代理绑定对象实例
        /// </summary>
        private System.ServiceModel.Channels.Binding Binding { get; set; }



        /// <summary>
        /// 终结点名
        /// </summary>
        public string EndPoint { get; private set; }


        /// <summary>
        /// 返回一个WCF通道工厂实例
        /// </summary>
        private ChannelFactory<IWcfPortal> GetChannelFactory(DataPortalContext context)
        {

            string bizEndPoint = context.EndPointName;
            if (!string.IsNullOrWhiteSpace(bizEndPoint))
            {
                return new ChannelFactory<IWcfPortal>(bizEndPoint);
            }
            return new ChannelFactory<IWcfPortal>(EndPoint);
        }

        /// <summary>
        /// 返回数据门户的WCF代理
        /// </summary>
        /// <param name="cf">
        /// 通道工厂
        /// </param>
        private IWcfPortal GetProxy(ChannelFactory<IWcfPortal> cf)
        {
            return cf.CreateChannel();
        }

        public OperateState Insert(T obj)
        {
            ChannelFactory<IWcfPortal> cf = GetChannelFactory(obj.Context);
            var proxy = GetProxy(cf);
            WcfResponse response = null;
            try
            {
                // 
                var request = new InsertRequest(obj);


                response = proxy.InsertAsync(request).Result;

                if (cf != null)
                    cf.Close();
            }
            catch
            {
                cf.Abort();
                throw new Exception("WCF ChannelFactory执行 Insert 方法失败");
            }
            object result = response.Result;
            if (result is Exception)
                throw (Exception)result;
            //DataPortalResult resultobj = new DataPortalResult((OperateState)result);
            //TraceDo(cf, resultobj);
            return (OperateState)result;
        }

        public T Fetch(T obj)
        {
            if (!(obj is IBusinessFetch))
            {
                throw new Exception("未实现 Fetch 方法");
            }
            ChannelFactory<IWcfPortal> cf = GetChannelFactory(obj.Context);
            var proxy = GetProxy(cf);
            WcfResponse response = null;
            try
            {
                FetchRequest request = null;
                if (obj is IBusinessContext)
                {
                    request = new FetchRequest(typeof(T), (obj as IBusinessContext).Criteria, obj.Context);

                }
                else if (obj is IBusinessListContext)
                {
                    request = new FetchRequest(typeof(T), (obj as IBusinessListContext).Criteria, obj.Context);
                }


                response = proxy.FetchAsync(request).Result;

                if (cf != null)
                    cf.Close();
            }
            catch
            {
                cf.Abort();
                throw new Exception("WCF ChannelFactory执行 Fetch 方法失败");
            }
            object result = response.Result;
            if (result is Exception)
                throw (Exception)result;
            DataPortalResult resultobj = (DataPortalResult)result;
            TraceDo(cf, resultobj);
            return (T)resultobj.ReturnObject;
        }

        public OperateState Update(T obj)
        {
            if (!(obj is IBusinessUpdate))
            {
                throw new Exception("未实现 Update 方法");
            }
            ChannelFactory<IWcfPortal> cf = GetChannelFactory(obj.Context);
            var proxy = GetProxy(cf);
            WcfResponse response = null;
            try
            {
                var request = new UpdateRequest(obj);


                response = proxy.UpdateAsync(request).Result;

                if (cf != null)
                    cf.Close();
            }
            catch
            {
                cf.Abort();
                throw new Exception("WCF ChannelFactory执行 Update 方法失败");
            }
            object result = response.Result;
            if (result is Exception)
                throw (Exception)result;
            //DataPortalResult resultobj =new DataPortalResult( (OperateState)result);
            //TraceDo(cf, resultobj);
            return (OperateState)result;
        }

        public OperateState Delete(T obj)
        {
            if (!(obj is IBusinessDelete))
            {
                throw new Exception("未实现 Delete 方法");
            }
            ChannelFactory<IWcfPortal> cf = GetChannelFactory(obj.Context);
            var proxy = GetProxy(cf);
            WcfResponse response = null;
            try
            {

                DeleteRequest request = null;
                if (obj is IBusinessContext)
                {
                    request = new DeleteRequest(typeof(T), (obj as IBusinessContext).Criteria, obj.Context);

                }
                else if (obj is IBusinessListContext)
                {
                    request = new DeleteRequest(typeof(T), (obj as IBusinessListContext).Criteria, obj.Context);
                }



                response = proxy.DeleteAsync(request).Result;

                if (cf != null)
                    cf.Close();
            }
            catch
            {
                cf.Abort();
                throw new Exception("WCF ChannelFactory执行 Delete 方法失败");
            }
            object result = response.Result;
            if (result is Exception)
                throw (Exception)result;
            //DataPortalResult resultobj = new DataPortalResult((OperateState)result);
            //TraceDo(cf, resultobj);
            return (OperateState)result;
        }

        public OperateState Execute(T obj)
        {
            if (!(obj is IBusinessExecute))
            {
                throw new Exception("未实现 Execute 方法");
            }
            ChannelFactory<IWcfPortal> cf = GetChannelFactory(obj.Context);
            var proxy = GetProxy(cf);
            WcfResponse response = null;
            try
            {
                var request = new ExecuteRequest(obj);


                response = proxy.ExecuteAsync(request).Result;

                if (cf != null)
                    cf.Close();
            }
            catch
            {
                cf.Abort();
                throw new Exception("WCF ChannelFactory执行 Execute 方法失败");
            }
            object result = response.Result;
            if (result is Exception)
                throw (Exception)result;
            //DataPortalResult resultobj = new DataPortalResult((OperateState)result);
            //TraceDo(cf, resultobj);
            return (OperateState)result;
        }


        public T SpFetch(T obj)
        {
            if (!(obj is IBusinessSpFetch))
            {
                throw new Exception("未实现 SpFetch 方法");
            }
            ChannelFactory<IWcfPortal> cf = GetChannelFactory(obj.Context);
            var proxy = GetProxy(cf);
            WcfResponse response = null;
            try
            {
                var request = new SpFetchRequest(obj);


                response = proxy.SpFetchAsync(request).Result;

                if (cf != null)
                    cf.Close();
            }
            catch
            {
                cf.Abort();
                throw new Exception("WCF ChannelFactory执行 SpFetch 方法失败");
            }
            object result = response.Result;
            if (result is Exception)
                throw (Exception)result;
            DataPortalResult resultobj = (DataPortalResult)result;
            TraceDo(cf, resultobj);
            return (T)resultobj.ReturnObject;
        }

        public OperateState BatchSave(T obj)
        {
            if (!(obj is IBusinessUpdate))
            {
                throw new Exception("未实现 Update 方法");
            }
            ChannelFactory<IWcfPortal> cf = GetChannelFactory(obj.Context);
            var proxy = GetProxy(cf);
            WcfResponse response = null;
            try
            {
                BatchSaveRequest request = null;
                if (obj is IBusinessListContext)
                {
                    request = new BatchSaveRequest(typeof(T), (obj as IBusinessListContext).Criteria, obj.Context);
                }

                response = proxy.BatchSaveAsync(request).Result;

                if (cf != null)
                    cf.Close();
            }
            catch
            {
                cf.Abort();
                throw new Exception("WCF ChannelFactory执行 BatchSave 方法失败");
            }
            object result = response.Result;
            if (result is Exception)
                throw (Exception)result;
            //DataPortalResult resultobj = new DataPortalResult((OperateState)result);
            //TraceDo(cf, resultobj);
            return (OperateState)result;
        }
        /// <summary>
        /// 返回标识
        /// </summary>
        /// <param name="cf">WCF通道工厂</param>
        /// <param name="resultobj">数据门返回实例</param>
        private void TraceDo(ChannelFactory<IWcfPortal> cf, DataPortalResult resultobj)
        {
            resultobj.ReturnObject.TraceSignAddress("Address:" + cf.Endpoint.Address.Uri.ToString() + " binding:" + cf.Endpoint.Binding.Name);
        }
    }
}
