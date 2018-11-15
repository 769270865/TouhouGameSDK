using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touhou.Core.Configuration
{
    public interface ISettingIO
    {
        Setting GetDefaultSetting();
        Setting GetCustomizSetting();
        void SaveSetting(Setting customizedSetting);
        void ResetSetting();
    }
}
