using Atk.DataPortal;
using Atk.DataPortal.Core;

namespace DemoTools.BLL.DemoNorthwind
{
    /// <summary>
    /// AzCustOrdersDetail 数据访问接口定义
    /// azItem:业务实例
    /// context:访问上下文
    /// </summary>
    public interface IAzCustOrdersDetailDal
    {
       
        void DB_Execute(AzCustOrdersDetailEntity azItem);

    }
}