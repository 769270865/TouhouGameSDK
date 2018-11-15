using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Touhou.Core.Configuration
{
    public class SettingContext : MonoBehaviour
    {
        ISettingIO SettingIO;
       

        public static Setting CurrentSetting { get; private set; }
        public static readonly Setting DefaultSetting = new Setting()
        {
            ShootKey = KeyCode.Z,
            BoomKey = KeyCode.X,
            FocuseKey = KeyCode.LeftShift,
            BGM_Volume = 0.8f,
            SFX_Volume = 0.5f,
            PlayerBoom = 4,
            PlayerLife = 4
        }; 

        [Inject]
        public void Construct(ISettingIO settingIO)
        {
            SettingIO = settingIO;
         
        }

        public Setting GetDefaultSetting() => SettingIO.GetDefaultSetting();

        public Setting GetCustomizedSetting() => SettingIO.GetCustomizSetting();

        public void SaveSetting(Setting setting) => SettingIO.SaveSetting(setting);

       

        private void Awake()
        {
            intializeSetting();

        }

        private void intializeSetting()
        {
            if (GetDefaultSetting() == null)
                SaveSetting(DefaultSetting);

            CurrentSetting = GetCustomizedSetting() ?? DefaultSetting;
        }
    }
}
