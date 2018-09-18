using System;

namespace Atk.DataPortal.Core
{
    /// <summary>
    /// 可读写业务对象抽象类
    /// 主要用于非存储操作类的基类
    /// 此标记也是批更新，或调用Save方法时用
    /// </summary>
    [Serializable]
    public abstract class BusinessEditBase : BusinessBase
    {
    

      

    }
}
