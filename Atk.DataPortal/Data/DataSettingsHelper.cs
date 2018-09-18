using Atk.DataPortal.Core;
using Atk.Tool.Cryptogram;
using System.Collections.Generic;
using System.Linq;

namespace Atk.DataPortal
{
    /// <summary>
    /// 数据库设计辅助类
    /// </summary>
    public class DataSettingsHelper
    {
        private static bool? _databaseIsInstalled;

        private static IDictionary<string, DataPortalContext> _dataSettings;
        //private IDataSettingsManager _dataSettingsManager;

        //public DataSettingsHelper(IDataSettingsManager dataSettingsManager)
        //{
        //    _dataSettingsManager = dataSettingsManager;
        //}

        /// <summary>
        /// 返回一个值，指示当前数据库是否已经设置
        /// </summary>
        /// <returns>返回结果</returns>
        public static bool DatabaseIsInstalled(IDataSettingsManager dataSettingsManager)
        {
            if (!_databaseIsInstalled.HasValue)
            {
                var _dataManager = dataSettingsManager;// new DataSettingsManager();
                _dataSettings = _dataManager.LoadSettings();
                _databaseIsInstalled = _dataSettings != null && _dataSettings.Count() > 0;
            }
            return _databaseIsInstalled.Value;
        }

        /// <summary>
        /// 重置设置
        /// </summary>
        public static void ResetCache()
        {
            _databaseIsInstalled = null;
        }

        /// <summary>
        /// 获取指定数据库键的连接信息
        /// </summary>
        /// <param name="businessZone">Settings.xml  中 key 的值</param>
        /// <returns>数据门户</returns>
        public static DataPortalContext GetCurrentDataSetting(string businessZone)
        {
            DataPortalContext result = new DataPortalContext();
            result.DbConnectionKey = businessZone;

            if (!_databaseIsInstalled.Value)
            {
                return new DataPortalContext();
            }
            _dataSettings.TryGetValue(businessZone, out result);
            result.DbConnectionKey = businessZone;

            DataPortalContext result2 = new DataPortalContext();
            if (result.CnnIsEncryption)
            {
                string ekey = result.DbConnectionKey + "athinker";
                result2.DbConnectionString = SymmetricEncryption.BizDecrypt(result.DbConnectionString, ekey);
            }
            //  
            //  
            result2.DbConnectionString = result.DbConnectionString;
            result2.IsTransaction = result.IsTransaction;
            result2.IsWcf = result.IsWcf;
            result2.DbConnectionKey = businessZone;
            result2.EndPointName = result.EndPointName;
            result2.CnnIsEncryption = result.CnnIsEncryption;

            return result2;
        }
    }
}
