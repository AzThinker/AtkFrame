using Atk.DataPortal.Core;

namespace Atk.DataPortal.UiServer
{
    /// <summary>
    /// UI服务类基类
    /// </summary>
    /// <typeparam name="D">UI业务类</typeparam>
    /// <typeparam name="E">BLL业务类</typeparam>
    public abstract class BaseUIEditDto<D, E> : BaseUIDto<D, E>
        where D : BaseUIDto<D, E>
        where E : BusinessBase
    {

    }
}
