using Atk.DataPortal;
using Atk.DataPortal.Core;
using Autofac;
using Module = Autofac.Module;



namespace Atk.DataPortal
{
    /// <summary>
    /// 基类注册模块
    /// </summary>
    public class AutoRegister_Module : Module
    {
        /// <summary>
        /// IOC注册
        /// </summary>
        /// <param name="moduleBuilder">模块注册</param>
        protected override void Load(ContainerBuilder moduleBuilder)
        {
            moduleBuilder.Register(ctx => new WorkContextImplementation(ctx.Resolve<IComponentContext>())).As<DataPortalWorkContext>();
            moduleBuilder.RegisterType<Power>();
            moduleBuilder.RegisterType<DataPortalContext>();
            moduleBuilder.RegisterGeneric(typeof(DataPortal<>)).As(typeof(IDataPortal<>));
            moduleBuilder.RegisterGeneric(typeof(DataPortalList<,>)).As(typeof(IDataPortalList<,>));

        }
    }
}
