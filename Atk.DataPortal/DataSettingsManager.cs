using Atk.DataPortal.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Hosting;
using System.Xml;

namespace Atk.DataPortal
{
    /// <summary>
    /// Manager of data settings (connection string)
    /// </summary>
    public partial class DataSettingsManager
    {
        /// <summary>
        /// 配置文件名称
        /// </summary>
        protected const string filename = "Settings.xml";

        /// <summary>
        /// Maps a virtual path to a physical disk path.
        /// </summary>
        /// <param name="path">The path to map. E.g. "~/bin"</param>
        /// <returns>The physical path. E.g. "c:\inetpub\wwwroot\bin"</returns>
        protected virtual string MapPath(string path)
        {
            if (HostingEnvironment.IsHosted)
            {
                //hosted
                return HostingEnvironment.MapPath(path);
            }

            //not hosted. For example, run in unit tests
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            path = path.Replace("~/", "").TrimStart('/').Replace('/', '\\');

            return Path.Combine(baseDirectory, path);
        }

        /// <summary>
        /// Parse settings
        /// </summary>
        /// <returns>Parsed data settings</returns>
        protected virtual IDictionary<string, DataPortalContext> ParseSettings()
        {

            string filePath = Path.Combine(MapPath("~/App_Data/"), filename);

            if (!File.Exists(filePath))
            {
                new Exception("没有数据库设置！");
            }

            XmlDocument doc = new XmlDocument();
            XmlReaderSettings settings = new XmlReaderSettings();

            settings.IgnoreComments = true;//忽略文档里面的注释

            XmlReader reader = XmlReader.Create(filePath, settings);
            doc.Load(reader);
            XmlNode node = doc.SelectSingleNode("/DataSettings/Setting");

            Dictionary<string, DataPortalContext> result = new Dictionary<string, DataPortalContext>();

            if (node != null)
            {
                XmlNodeList xnl = node.ChildNodes;
                foreach (var item in xnl)
                {
                    XmlElement xe = (XmlElement)item;
                    DataPortalContext ds = new DataPortalContext();
                    string setname = xe.GetAttribute("key");
                    ds.DbConnectionString = xe.GetAttribute("DataConnectionString");
                    ds.CnnIsEncryption = xe.GetAttribute("IsEncryption").ToLower() == "true";
                    ds.IsWcf = xe.GetAttribute("IsWcf").ToLower() == "true";
                    ds.EndPointName = xe.GetAttribute("EndPointName");
                    ds.IsTransaction = xe.GetAttribute("IsTransaction").ToLower() == "true";
                    result.Add(setname, ds);
                }

            }
            reader.Close();
            return result;
        }


        /// <summary>
        /// Load settings
        /// </summary>
        /// <param name="filePath">File path; pass null to use default settings file path</param>
        /// <returns>返回结果</returns>
        public virtual IDictionary<string, DataPortalContext> LoadSettings(string filePath = null)
        {

            return ParseSettings();
        }


    }
}
