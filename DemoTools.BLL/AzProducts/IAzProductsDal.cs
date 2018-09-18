using Atk.DataPortal;
using Atk.DataPortal.Core;

namespace DemoTools.BLL.DemoNorthwind
{
    /// <summary>
    /// 产品 数据访问接口定义
    /// AzItem:业务实例
    /// </summary>
    public interface IAzProductsDal
    {
       
        	void DB_Insert(AzProductsEntity azItem);
	void DB_Update(AzProductsEntity azItem);
	void DB_Delete(AzProductsEntity azItem);
	void DB_Fetch(AzProductsEntity azItem);
	void DB_FetchList(AzProductsListEntity azItems);


    }
}
