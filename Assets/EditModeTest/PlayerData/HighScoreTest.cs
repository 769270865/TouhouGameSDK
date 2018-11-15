using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Touhou.Core.Player.Data;
using Touhou.PlayerScore.HighScore;
using Touhou.Core.Enemy;
using System.Collections.Generic;

namespace PlayerDataTest
{
    public class HighScoreTest
    {
        [Test]
        public void HighScoreEqualTest()
        {
            HighScore score1 = new HighScore(new SelectedGame(new SelectedCharacter(0, 1), new SelectedStages(0, SelectedStages.StageDiffculity.Easy)), 10000);
            HighScore score2 = new HighScore(new SelectedGame(new SelectedCharacter(0, 1), new SelectedStages(0, SelectedStages.StageDiffculity.Easy)), 10000);

            Assert.That(score1.Equals(score2));
        }
        [Test]
        public void HighScoreNotEqualTest()
        {
            HighScore score1 = new HighScore(new SelectedGame(new SelectedCharacter(0, 1), new SelectedStages(0, SelectedStages.StageDiffculity.Easy)), 10000);
            HighScore score2 = new HighScore(new SelectedGame(new SelectedCharacter(0, 1), new SelectedStages(0, SelectedStages.StageDiffculity.Easy)), 10001);

            Assert.That(!score1.Equals(score2));
        }
    }
}