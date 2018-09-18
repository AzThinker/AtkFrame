namespace Atk.DataPortal
{
    /// <summary>
    /// 基本权限
    /// </summary>
    public class Power
    {
        /// <summary>
        /// 增加
        /// </summary>
        public bool Create { get; set; }

        /// <summary>
        /// 获取
        /// </summary>
        public bool Get { get; set; }

        /// <summary>
        /// 编辑
        /// </summary>
        public bool Edit { get; set; }

        /// <summary>
        /// 执行
        /// </summary>
        public bool Execute { get; set; }


        /// <summary>
        /// 批处理
        /// </summary>
        public bool BatchDo { get; set; }

        /// <summary>
        /// 删除
        /// </summary>
        public bool Delete { get; set; }

        /// <summary>
        /// 报表
        /// </summary>
        public bool Report { get; set; }

        /// <summary>
        /// 审核
        /// </summary>
        public bool Check { get; set; }

        /// <summary>
        /// 导出
        /// </summary>
        public bool Export { get; set; }

        /// <summary>
        /// 导入
        /// </summary>
        public bool ExportIn { get; set; }

        /// <summary>
        /// 基本权限
        /// </summary>
        public Power()
        {
            Create = true;
            Get = true;
            Edit = true;
            Delete = true;
            Report = true;
            Check = true;
            Export = true;
            ExportIn = true;
            BatchDo = true;
            Execute = true;
        }


    }
}
