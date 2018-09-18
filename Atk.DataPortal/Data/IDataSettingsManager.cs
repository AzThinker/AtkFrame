using System.Collections.Generic;
using Atk.DataPortal.Core;

namespace Atk.DataPortal
{
    public interface IDataSettingsManager
    {
        IDictionary<string, DataPortalContext> LoadSettings(string filePath = null);
        string MapPath(string path);
        IDictionary<string, DataPortalContext> ParseSettings();
    }
}