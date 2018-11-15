using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touhou.PlayerScore.Score
{
    [Serializable]
    public struct PlayerScore : IEquatable<PlayerScore>
    {
        public int Point { get; set; }
        public int Graze { get; set; }

        public enum Stage
        {
            Stage1, Stage2, Stage3, Stage4, Stage5, Stage6, Extra, Phantasm
        }

        public Stage LastClearedStage { get; set; }

        public float GameCompletionPercentage { get; set; }


        public PlayerScore(int point, int graze, Stage lastClearedStage, float gameCompletionPercentage)
        {
            Point = point;
            Graze = graze;
            LastClearedStage = lastClearedStage;
            GameCompletionPercentage = gameCompletionPercentage;
        }

        public override bool Equals(object obj)
        {
            return obj is PlayerScore && Equals((PlayerScore)obj);
        }

        public bool Equals(PlayerScore other)
        {
            return Point == other.Point &&
                   Graze == other.Graze &&
                   LastClearedStage == other.LastClearedStage &&
                   GameCompletionPercentage == other.GameCompletionPercentage;
        }

        public override int GetHashCode()
        {
            var hashCode = -928731285;
            hashCode = hashCode * -1521134295 + Point.GetHashCode();
            hashCode = hashCode * -1521134295 + Graze.GetHashCode();
            hashCode = hashCode * -1521134295 + LastClearedStage.GetHashCode();
            hashCode = hashCode * -1521134295 + GameCompletionPercentage.GetHashCode();
            return hashCode;
        }
    }
}
