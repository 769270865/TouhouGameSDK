using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Touhou.Core.Enemy;
using Touhou.Core.Player.Data;
using Touhou.PlayerScore.Score;

namespace PlayerDataTest
{

    public class PlayerScoreRecordTest
    {
        [Test]
        public void PlayerScoreEqualTest()
        {
            PlayerScoreRecord playerScoreRecord1 = new PlayerScoreRecord(
                                                                        new PlayerScore(21505, 500, PlayerScore.Stage.Stage4, 0.45f),
                                                                        new SelectedGame(new SelectedCharacter(0, 0), new SelectedStages(0, SelectedStages.StageDiffculity.Easy)),
                                                                        "Foo",
                                                                        new DateTime(2018, 7, 15, 16, 0, 0));
            PlayerScoreRecord playerScoreRecord2 = new PlayerScoreRecord(
                                                                        new PlayerScore(21505, 500, PlayerScore.Stage.Stage4, 0.45f),
                                                                        new SelectedGame(new SelectedCharacter(0, 0), new SelectedStages(0, SelectedStages.StageDiffculity.Easy)),
                                                                        "Foo",
                                                                        new DateTime(2018, 7, 15, 16, 0, 0));
            Assert.That(playerScoreRecord1.Equals(playerScoreRecord2));
        }
        [Test]
        public void PlayerScoreNotEqualTest()
        {
            PlayerScoreRecord playerScoreRecord1 = new PlayerScoreRecord(
                                                                        new PlayerScore(21505, 500, PlayerScore.Stage.Stage4, 0.45f),
                                                                        new SelectedGame(new SelectedCharacter(0, 0), new SelectedStages(0, SelectedStages.StageDiffculity.Easy)),
                                                                        "Foo",
                                                                        new DateTime(2018, 7, 15, 16, 0, 0));
            PlayerScoreRecord playerScoreRecord2 = new PlayerScoreRecord(
                                                                        new PlayerScore(21505, 500, PlayerScore.Stage.Stage4, 0.45f),
                                                                        new SelectedGame(new SelectedCharacter(0, 0), new SelectedStages(0, SelectedStages.StageDiffculity.Easy)),
                                                                        "Bar",
                                                                        new DateTime(2018, 7, 15, 16, 0, 0));

            Assert.That(!playerScoreRecord1.Equals(playerScoreRecord2));
        }
    }
}