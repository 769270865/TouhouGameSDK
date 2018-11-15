using Sirenix.Serialization;
using System.Collections.Generic;
using UnityEngine;

namespace Touhou.Core.Enemy
{
    public class StageCatainer
    {
        [OdinSerialize]
        List<IEnemyComponent> stageComponents;
        public List<IEnemyComponent> StageComponents => stageComponents;


        [SerializeField]
        StageID stageID;
        public StageID StageID => stageID;

    }
}