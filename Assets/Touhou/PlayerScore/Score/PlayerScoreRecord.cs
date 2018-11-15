using System;
using Touhou.Core.Player.Data;

namespace Touhou.PlayerScore.Score
{
    [Serializable]
    public class PlayerScoreRecord : IEquatable<PlayerScoreRecord>
    {
        public PlayerScore PlayerScore { get; set; }
        public SelectedGame SelectedGame { get; set; }

        public string PlayerName { get; set; }
        public DateTime RecordDate { get; set; }


        public PlayerScoreRecord(PlayerScore playerScore, SelectedGame selectedGame, string playerName, DateTime recordData)
        {
            PlayerScore = playerScore;
            SelectedGame = selectedGame;
            PlayerName = playerName;
            RecordDate = recordData;
        }

        public override bool Equals(object obj)
        {
            return obj is PlayerScoreRecord && Equals(obj as PlayerScoreRecord);
        }

        public bool Equals(PlayerScoreRecord other)
        {
            if (other == null)
            {
                return false;
            }
            if (other.GetType() != this.GetType())
            {
                return false;
            }

            return PlayerScore.Equals(other.PlayerScore) && SelectedGame.Equals(other.SelectedGame) &&
                   PlayerName == other.PlayerName &&
                   RecordDate == other.RecordDate;

        }

        public override int GetHashCode()
        {
            var hashCode = 2020233827;
            hashCode = hashCode * -1521134295 + PlayerScore.GetHashCode();
            hashCode = hashCode * -1521134295 + SelectedGame.GetHashCode();
            hashCode = hashCode * -1521134295 + PlayerName.GetHashCode();
            hashCode = hashCode * -1521134295 + RecordDate.GetHashCode();
            return hashCode;
        }
    }
}