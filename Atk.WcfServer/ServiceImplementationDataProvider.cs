using Autofac.Core;
using Autofac.Core.Lifetime;
using Autofac.Integration.Wcf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.ServiceModel;


namespace Atk.WcfServer
{
    /// <summary>
    /// autoface服务实现提供者，为autoface的WCF必需实现类
    /// （参看Autoface的WCF要求）
    /// </summary>
    public class ServiceImplementationDataProvider : IServiceImplementationDataProvider
    {
        public virtual ServiceImplementationData GetServiceImplementationData(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (value.Length == 0)
            {
                throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, "参数为空", "value"));
            }
            if (AutofacHostFactory.Container == null)
            {
                throw new InvalidOperationException("容器为空");
            }
            IComponentRegistration registration = null;
            if (!AutofacHostFactory.Container.ComponentRegistry.TryGetRegistration(new KeyedService(value, typeof(object)), out registration))
            {
                Type serviceType = Type.GetType(value, false);
                if (serviceType != null)
                {
                    AutofacHostFactory.Container.ComponentRegistry.TryGetRegistration(new TypedService(serviceType), out registration);
                }
            }

            if (registration == null)
            {
                throw new InvalidOperationException(String.Format(CultureInfo.CurrentCulture, "服务没注册", value));
            }

            var data = new ServiceImplementationData
            {
                ConstructorString = value,
                ServiceTypeToHost = registration.Activator.LimitType,
                ImplementationResolver = l => l.ResolveComponent(registration, Enumerable.Empty<Parameter>())
            };

            var implementationType = registration.Activator.LimitType;
            if (IsSingletonWcfService(implementationType))
            {
                if (!IsRegistrationSingleInstance(registration))
                {
                    throw new InvalidOperationException(String.Format(CultureInfo.CurrentCulture, "服务必需是单例", implementationType.FullName));
                }

                data.HostAsSingleton = true;
            }
            else
            {
                if (IsRegistrationSingleInstance(registration))
                {
                    throw new InvalidOperationException(String.Format(CultureInfo.CurrentCulture, "服务必需是单例", implementationType.FullName));
                }
            }

            return data;
        }

        static bool IsRegistrationSingleInstance(IComponentRegistration registration)
        {
            return registration.Sharing == InstanceSharing.Shared && registration.Lifetime is RootScopeLifetime;
        }

        static bool IsSingletonWcfService(Type implementationType)
        {
            var behavior = implementationType
                .GetCustomAttributes(typeof(ServiceBehaviorAttribute), true)
                .OfType<ServiceBehaviorAttribute>()
                .FirstOrDefault();

            return behavior != null && behavior.InstanceContextMode == InstanceContextMode.Single;
        }
    }
}
