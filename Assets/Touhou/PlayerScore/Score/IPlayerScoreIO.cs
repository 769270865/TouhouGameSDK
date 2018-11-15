using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touhou.PlayerScore.Score
{
    public interface IPlayerScoreIO
    {
        void SavePlayerScore(PlayerScoreRecord playerScoreRecord);
        List<PlayerScoreRecord> GetAllPlayerRecord();
        void DeleteAllPlayerScore();


        PlayerScoreRecord GetPlayerScore(Predicate<PlayerScoreRecord> match);
        List<PlayerScoreRecord> GetPlayerScores(Func<PlayerScoreRecord, bool> matches);
        void ReloadPlayerScoresFromSave();
    }
}
