using Atk.DataPortal;
using Atk.DataPortal.Core;

namespace DemoTools.BLL.DemoNorthwind
{
    /// <summary>
    /// 订单 数据访问接口定义
    /// AzItem:业务实例
    /// </summary>
    public interface IAzOrdersDal
    {
       
        	void DB_Insert(AzOrdersEntity azItem);
	void DB_Update(AzOrdersEntity azItem);
	void DB_Delete(AzOrdersEntity azItem);
	void DB_Fetch(AzOrdersEntity azItem);
	void DB_FetchList(AzOrdersListEntity azItems);


    }
}
