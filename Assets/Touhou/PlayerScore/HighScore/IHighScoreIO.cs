using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touhou.PlayerScore.HighScore
{
    public interface IHighScoreIO
    {
        void SavePlayerHighScore(HighScore highScore);
        List<HighScore> GetAllHighScore();
        void DeleteAllHighScore();

        HighScore GetHighScore(Predicate<HighScore> match);
        List<HighScore> GetHighScores(Func<HighScore, bool> matches);
        void ReloadPlayerHighScores();
    }
}
