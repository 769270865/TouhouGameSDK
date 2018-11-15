using Sirenix.Serialization;
using System;
using System.Collections.Generic;

namespace Touhou.Core.Enemy
{
    [Serializable]
    public class MainStageCatainer
    {
        [OdinSerialize]
        public List<IStage> Stages;

        public SelectedStages.StageDiffculity Diffculity;

        public int MainStageID;


    }
}