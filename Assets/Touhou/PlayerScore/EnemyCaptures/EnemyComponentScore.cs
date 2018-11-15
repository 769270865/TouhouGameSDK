using System;

namespace Touhou.PlayerScore.EnemyCaptures
{
    [Serializable]
    public struct EnemyComponentScore : IEquatable<EnemyComponentScore>
    {
        public readonly float CaptureTime;
        public readonly int GrazePoint;


        public EnemyComponentScore(float captureTime, int grazePoint)
        {
            CaptureTime = captureTime;
            GrazePoint = grazePoint;

        }

        public override bool Equals(object obj)
        {
            return obj is EnemyComponentScore && Equals((EnemyComponentScore)obj);
        }

        public bool Equals(EnemyComponentScore other)
        {
            return CaptureTime == other.CaptureTime &&
                   GrazePoint == other.GrazePoint;
        }

        public override int GetHashCode()
        {
            var hashCode = 632687792;
            hashCode = hashCode * -1521134295 + CaptureTime.GetHashCode();
            hashCode = hashCode * -1521134295 + GrazePoint.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Compare which score is higher, return false if equal
        /// </summary>
        /// <param name="x">Score compared to</param>      
        /// <returns>Compare which score is higher, return false if equal</returns>
        public bool IsScoreHigherThen(EnemyComponentScore x)
        {
            if (CaptureTime < x.CaptureTime || GrazePoint > x.GrazePoint)
                return true;
            else
                return false;

        }
    }
}