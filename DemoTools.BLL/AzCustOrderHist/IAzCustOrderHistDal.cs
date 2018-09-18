using Atk.DataPortal;
using Atk.DataPortal.Core;

namespace DemoTools.BLL.DemoNorthwind
{
    /// <summary>
    /// AzCustOrderHist 数据访问接口定义
    /// azItem:业务实例
    /// context:访问上下文
    /// </summary>
    public interface IAzCustOrderHistDal
    {
       
       void DB_SpFetch(AzCustOrderHistListEntity azItems);

    }
}