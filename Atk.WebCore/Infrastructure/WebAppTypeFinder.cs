using System;
using System.Collections.Generic;
using System.Reflection;


namespace Atk.WebCore.Infrastructure
{
    /// <summary>
    /// 提供有关当前 web 应用程序中的类型信息。
    ///（可选） 此类可以查看在 bin 文件夹中的所有程序集。
    /// </summary>
    public class WebAppTypeFinder : AppDomainTypeFinder
    {
        #region Fields

        //Bin文件夹是否已经引导
        private bool _binFolderAssembliesLoaded;

        #endregion

        #region Ctor

        /// <summary>
        /// Web应用类型发现构造方法
        /// </summary>
        public WebAppTypeFinder()
        {
            //this._ensureBinFolderAssembliesLoaded = config.DynamicDiscovery;
        }

        #endregion



        #region Methods

        /// <summary>
        /// 获取 \Bin 目录的物理地址
        /// </summary>
        /// <returns>物理地址如： "c:\inetpub\wwwroot\bin"</returns>
        public virtual string GetBinDirectory()
        {
            return AppContext.BaseDirectory;
        }

        /// <summary>
        /// 获取程序集
        /// </summary>
        /// <returns>程序集</returns>
        public override IList<Assembly> GetAssemblies()
        {
            //this.EnsureBinFolderAssembliesLoaded &&
            if (!_binFolderAssembliesLoaded)
            {
                _binFolderAssembliesLoaded = true;
                string binPath = GetBinDirectory();
                LoadMatchingAssemblies(binPath);
            }

            return base.GetAssemblies();
        }

        #endregion
    }
}
