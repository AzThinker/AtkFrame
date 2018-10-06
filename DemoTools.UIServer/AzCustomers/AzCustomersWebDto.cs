using System;
using System.ComponentModel.DataAnnotations;
using Atk.DataPortal;
using Atk.DataPortal.Core;
using Atk.DataPortal.UiServer;
using Autofac;
using DemoTools.BLL.DemoNorthwind;

// 客户 UI的Dto类
namespace DemoTools.UIServer.DemoNorthwind
{
    /// <summary>
    /// 客户   UI的Dto类
    /// </summary>
    public class AzCustomersWebDto : BaseUIDto<AzCustomersWebDto, AzCustomersEntity>, IComparable<AzCustomersWebDto>
    {
        #region  属性定义
        /// <summary>
        /// 中文名称
        /// </summary>
        [ScaffoldColumn(false)]
        public static string DisplayDescription { get; set; }

        /// <summary>
        ///CustomerID_simpCN
        /// </summary>
        [Display(Name = "CustomerID_simpCN")]
        public string CustomerID { get; set; }
        /// <summary>
        ///CompanyName_simpCN
        /// </summary>
        [Display(Name = "CompanyName_simpCN")]
        public string CompanyName { get; set; }
        /// <summary>
        ///ContactName_simpCN
        /// </summary>
        [Display(Name = "ContactName_simpCN")]
        public string ContactName { get; set; }
        /// <summary>
        ///ContactTitle_simpCN
        /// </summary>
        [Display(Name = "ContactTitle_simpCN")]
        public string ContactTitle { get; set; }
        /// <summary>
        ///Address_simpCN
        /// </summary>
        [Display(Name = "Address_simpCN")]
        public string Address { get; set; }
        /// <summary>
        ///City_simpCN
        /// </summary>
        [Display(Name = "City_simpCN")]
        public string City { get; set; }
        /// <summary>
        ///Region_simpCN
        /// </summary>
        [Display(Name = "Region_simpCN")]
        public string Region { get; set; }
        /// <summary>
        ///PostalCode_simpCN
        /// </summary>
        [Display(Name = "PostalCode_simpCN")]
        public string PostalCode { get; set; }
        /// <summary>
        ///Country_simpCN
        /// </summary>
        [Display(Name = "Country_simpCN")]
        public string Country { get; set; }
        /// <summary>
        ///Phone_simpCN
        /// </summary>
        [Display(Name = "Phone_simpCN")]
        public string Phone { get; set; }
        /// <summary>
        ///Fax_simpCN
        /// </summary>
        [Display(Name = "Fax_simpCN")]
        public string Fax { get; set; }


        #endregion

        #region 构造方法

        /// <summary>
        /// 客户 构造方法
        /// </summary>
        public AzCustomersWebDto(ILifetimeScope lc) : base()
        {
            _lc = lc;
            Power = new Power();
            Op = RecordOperater.Updata;
            DisplayDescription = "客户";

        }

        /// <summary>
        /// 客户 构造方法
        /// </summary>
        public AzCustomersWebDto() : base()
        {
            Power = new Power();
            Op = RecordOperater.Updata;
            DisplayDescription = "客户";

        }
        #endregion

        #region  属性拷贝

        /// <summary>
        /// 由BLL类型转换成UI的Dto类型
        /// </summary>
        /// <param name="item">BLL类型</param>
        public override AzCustomersWebDto CopyToOut(AzCustomersEntity item)
        {
            #region  类赋值
            this.CustomerID = item.CustomerID;//CustomerID_simpCN
            this.CompanyName = item.CompanyName;//CompanyName_simpCN
            this.ContactName = item.ContactName;//ContactName_simpCN
            this.ContactTitle = item.ContactTitle;//ContactTitle_simpCN
            this.Address = item.Address;//Address_simpCN
            this.City = item.City;//City_simpCN
            this.Region = item.Region;//Region_simpCN
            this.PostalCode = item.PostalCode;//PostalCode_simpCN
            this.Country = item.Country;//Country_simpCN
            this.Phone = item.Phone;//Phone_simpCN
            this.Fax = item.Fax;//Fax_simpCN
            #endregion

            this.SetAccessAddress(item.AccessAddress);
            this.SetAccessPath(item.AccessPath);
            return this;
        }

        /// <summary>
        /// 由Dto类型转换成BLL类型进行保存操作
        /// </summary>
        /// <param name="item">UI的Dto类型</param>
        public override AzCustomersEntity CopyToIn()
        {
            var data = _lc.Resolve<AzCustomersEntity>();
            #region  类赋值
            data.CustomerID = this.CustomerID;//CustomerID_simpCN
            data.CompanyName = this.CompanyName;//CompanyName_simpCN
            data.ContactName = this.ContactName;//ContactName_simpCN
            data.ContactTitle = this.ContactTitle;//ContactTitle_simpCN
            data.Address = this.Address;//Address_simpCN
            data.City = this.City;//City_simpCN
            data.Region = this.Region;//Region_simpCN
            data.PostalCode = this.PostalCode;//PostalCode_simpCN
            data.Country = this.Country;//Country_simpCN
            data.Phone = this.Phone;//Phone_simpCN
            data.Fax = this.Fax;//Fax_simpCN
            #endregion

            return data;
        }

        /// <summary>
        /// josn对象拷贝
        /// </summary>
        /// <returns></returns>
        public override object JsonCopy()
        {
            return new
            {
                #region  类赋值
                CustomerID = this.CustomerID,//CustomerID_simpCN
                CompanyName = this.CompanyName,//CompanyName_simpCN
                ContactName = this.ContactName,//ContactName_simpCN
                ContactTitle = this.ContactTitle,//ContactTitle_simpCN
                Address = this.Address,//Address_simpCN
                City = this.City,//City_simpCN
                Region = this.Region,//Region_simpCN
                PostalCode = this.PostalCode,//PostalCode_simpCN
                Country = this.Country,//Country_simpCN
                Phone = this.Phone,//Phone_simpCN
                Fax = this.Fax,//Fax_simpCN
                #endregion

                #region  类权限赋值
                AtkCheck = this.Power.Check,
                AtkCreate = this.Power.Create,
                AtkDelete = this.Power.Delete,
                AtkEdit = this.Power.Edit,
                AtkExport = this.Power.Export,
                AtkExportIn = this.Power.ExportIn,
                AtkGet = this.Power.Get,
                AtkReport = this.Power.Report
                #endregion
            };
        }

        /// <summary>
        /// 记录相同比较，用于批更新时，重复项目检查
        /// </summary>
        /// <param name="other">另一记录</param>
        /// <returns>相同返回为 0</returns>
        public override int CompareTo(AzCustomersWebDto other)
        {
            if (other == null)
            {
                return 1;
            }

            if (this.CustomerID == other.CustomerID)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        #endregion
    }


}
