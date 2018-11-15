using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Touhou.Core.Player;
using Touhou.Core.Player.Data;

namespace Touhou.PlayerScore.HighScore
{
    [Serializable]
    public class HighScore : IEquatable<HighScore>
    {
        public HighScore(SelectedGame selectedGame, int score)
        {
            SelectedGame = selectedGame;
            Score = score;
        }

        public SelectedGame SelectedGame { get; set; }
        public int Score { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as HighScore);
        }

        public bool Equals(HighScore other)
        {
            return other != null &&
                   EqualityComparer<SelectedGame>.Default.Equals(SelectedGame, other.SelectedGame) &&
                   Score == other.Score;
        }

        public override int GetHashCode()
        {
            var hashCode = 2107766179;
            hashCode = hashCode * -1521134295 +SelectedGame.GetHashCode();
            hashCode = hashCode * -1521134295 + Score.GetHashCode();
            return hashCode;
        }
    }
}
