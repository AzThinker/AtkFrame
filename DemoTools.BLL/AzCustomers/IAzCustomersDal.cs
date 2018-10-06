using Atk.DataPortal;
using Atk.DataPortal.Core;

namespace DemoTools.BLL.DemoNorthwind
{
    /// <summary>
    /// 客户 数据访问接口定义
    /// AzItem:业务实例
    /// </summary>
    public interface IAzCustomersDal
    {

        void DB_Insert(AzCustomersEntity azItem);
        void DB_Update(AzCustomersEntity azItem);
        void DB_Delete(AzCustomersEntity azItem);
        void DB_Fetch(AzCustomersEntity azItem);
        void DB_FetchList(AzCustomersListEntity azItems);


    }
}
