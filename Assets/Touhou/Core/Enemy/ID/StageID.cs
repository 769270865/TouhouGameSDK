using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touhou.Core.Enemy
{
    [Serializable]
    public struct StageID
    {
        public readonly SelectedStages.StageDiffculity StageDiffculity;

        public readonly int StageIDNumber;

        public readonly int StageSequence;

        public StageID(SelectedStages.StageDiffculity stageDiffculity, int stageIDNumber, int stageSequence)
        {
            StageDiffculity = stageDiffculity;
            StageIDNumber = stageIDNumber;
            StageSequence = stageSequence;
        }
    }
}
