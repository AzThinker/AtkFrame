using System;
using System.Collections.Generic;

namespace Atk.DataPortal.Core
{
    /// <summary>
    /// 业务对象抽象类
    /// </summary>
    [Serializable]
    public class BusinessListBase<D> : List<D>, IBusinessListObject
        where D : BusinessBase
    {
    }
}
