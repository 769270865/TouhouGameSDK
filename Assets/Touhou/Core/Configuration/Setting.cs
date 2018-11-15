using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Touhou.Core.Configuration
{
    public class Setting
    {
        public KeyCode ShootKey { get; set; }
        public KeyCode BoomKey { get; set; }
        public KeyCode FocuseKey { get; set; }

        public float SFX_Volume { get; set; }
        public float BGM_Volume { get; set; }

        public int PlayerLife { get; set; }
        public int PlayerBoom { get; set; }

        public Setting(){}
       

        public Setting(KeyCode shootKey, KeyCode boomKey, KeyCode focuseKey, float sFX_Volume, float bGM_Volume, int playerLife, int playerBoom)
        {
            ShootKey = shootKey;
            BoomKey = boomKey;
            FocuseKey = focuseKey;
            SFX_Volume = sFX_Volume;
            BGM_Volume = bGM_Volume;
            PlayerLife = playerLife;
            PlayerBoom = playerBoom;
        }
    }
}
