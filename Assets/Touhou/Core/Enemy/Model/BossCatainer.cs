using Sirenix.Serialization;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Touhou.Core.Enemy
{
    [Serializable]
    public class BossCatainer
    {
        public string BossName;
        public int SpellCount;
        public Sprite BossSprite;


        [OdinSerialize]
        List<IEnemyComponent> bossComponents;
        public List<IEnemyComponent> BossComponent => bossComponents;
    }
}