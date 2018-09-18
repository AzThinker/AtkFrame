using Autofac;

namespace Atk.WebCore.Infrastructure.DependencyManagement
{
    /// <summary>
    /// 依赖注注入接口，需要注入类型时，实现此接口
    /// 引擎就会自动注册到应用当中
    /// </summary>
    public interface IDependencyRegistrar
    {
        /// <summary>
        /// 注册方法
        /// </summary>
        /// <param name="builder">当前上下文容器</param>
        /// <param name="typeFinder">类型发现器</param>
        void Register(ContainerBuilder builder, ITypeFinder typeFinder);

        /// <summary>
        /// 注入时的顺序
        /// </summary>
        int Order { get; }
    }
}
