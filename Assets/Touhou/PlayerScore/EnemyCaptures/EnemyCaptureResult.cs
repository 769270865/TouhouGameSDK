using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Touhou.Core.Enemy;

namespace Touhou.PlayerScore.EnemyCaptures
{
    public class EnemyCaptureResult : IEquatable<EnemyCaptureResult>
    {
        public readonly EnemyComponentID CapturedComponentID;
        public readonly EnemyComponentScore CapturedComponentScore;

        public EnemyCaptureResult(EnemyComponentID enemyComponentID, EnemyComponentScore capturedEnemyComponentScore)
        {
            CapturedComponentID = enemyComponentID;
            CapturedComponentScore = capturedEnemyComponentScore;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as EnemyCaptureResult);
        }

        public bool Equals(EnemyCaptureResult other)
        {
            return other != null &&
                   CapturedComponentID.Equals(other.CapturedComponentID) &&
                   CapturedComponentScore.Equals(other.CapturedComponentScore);
        }

        public override int GetHashCode()
        {
            var hashCode = 1406944303;
            hashCode = hashCode * -1521134295 + CapturedComponentID.GetHashCode();
            hashCode = hashCode * -1521134295 + CapturedComponentScore.GetHashCode();
            return hashCode;
        }
    }
}
