using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Touhou.Core.Enemy;
using Touhou.Core.Player.Data;
using Touhou.IO.PlayerScore.Score;
using Touhou.PlayerScore.Score;

namespace PlayerDataTest
{
    public class PlayerScoresRepoTest
    {
        PlayerScoreIO playerScoreIO;
        List<PlayerScoreRecord> record = new List<PlayerScoreRecord>()
            {
                                                             new PlayerScoreRecord(
                                                                                   new PlayerScore(21505,500,PlayerScore.Stage.Stage4,0.45f),
                                                                                   new SelectedGame(new SelectedCharacter(0,0),new SelectedStages(0,SelectedStages.StageDiffculity.Easy)),
                                                                                   "Foo",
                                                                                   new DateTime(2018,7,15,16,0,0)),
                                                             new PlayerScoreRecord(
                                                                                   new PlayerScore(22501,550,PlayerScore.Stage.Stage4,0.48f),
                                                                                   new SelectedGame(new SelectedCharacter(1,0),new SelectedStages(0,SelectedStages.StageDiffculity.Easy)),
                                                                                   "Bar",
                                                                                   new DateTime(2018,7,15,16,30,0)),
                                                             new PlayerScoreRecord(
                                                                                   new PlayerScore(31560,720,PlayerScore.Stage.Stage5,0.75f),
                                                                                   new SelectedGame(new SelectedCharacter(0,1),new SelectedStages(1,SelectedStages.StageDiffculity.Normal)),
                                                                                   "Baz",
                                                                                   new DateTime(2018,7,15,17,45,0)),
                                                             new PlayerScoreRecord(
                                                                                   new PlayerScore(30150,655,PlayerScore.Stage.Stage5,0.72f),
                                                                                   new SelectedGame(new SelectedCharacter(1,1),new SelectedStages(1,SelectedStages.StageDiffculity.Normal)),
                                                                                   "Cirno",
                                                                                   new DateTime(2018,7,16,10,0,0)),
                                                             new PlayerScoreRecord(
                                                                                   new PlayerScore(88450,821,PlayerScore.Stage.Stage5,0.74f),
                                                                                   new SelectedGame(new SelectedCharacter(0,0),new SelectedStages(2,SelectedStages.StageDiffculity.Hard)),
                                                                                   "Yunarill",
                                                                                   new DateTime(2018,7,16,15,0,0)),
                };

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            
            FileStructure.CreatePlayerScorePersistenceFolder();

            playerScoreIO = new PlayerScoreIO();
            foreach (var score in record)
            {
                playerScoreIO.SavePlayerScore(score);
            }
            //playerScoreIO.ReloadPlayerScoresFromSave();
            

        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            FileStructure.DeleteAllPersistenceFiles();
        }

        [Test]
        public void GetPayerScoreRecordOnSelectedCharacterTest()
        {
            SelectedCharacter targetCharacter = new SelectedCharacter(0, 1);

            PlayerScoreRecord excepted = new PlayerScoreRecord(new PlayerScore(31560, 720, PlayerScore.Stage.Stage5, 0.75f),
                                                                new SelectedGame(new SelectedCharacter(0, 1), new SelectedStages(1, SelectedStages.StageDiffculity.Normal)),
                                                                "Baz",
                                                                new DateTime(2018, 7, 15, 17, 45, 0));


            PlayerScoreRecord actural = playerScoreIO.GetPlayerScore(p => p.SelectedGame.SelectedCharacter.Equals(targetCharacter));

            Assert.That(actural.Equals(excepted));
        }
        [Test]
        public void GetPlayerScoreRecordsOnDiffculity()
        {
            List<PlayerScoreRecord> excepted = new List<PlayerScoreRecord>() {  new PlayerScoreRecord(
                                                                                       new PlayerScore(31560,720,PlayerScore.Stage.Stage5,0.75f),
                                                                                       new SelectedGame(new SelectedCharacter(0,1),new SelectedStages(1,SelectedStages.StageDiffculity.Normal)),
                                                                                       "Baz",
                                                                                       new DateTime(2018,7,15,17,45,0)),

                                                                                new PlayerScoreRecord(
                                                                                       new PlayerScore(30150,655,PlayerScore.Stage.Stage5,0.72f),
                                                                                       new SelectedGame(new SelectedCharacter(1,1),new SelectedStages(1,SelectedStages.StageDiffculity.Normal)),
                                                                                       "Cirno",
                                                                                       new DateTime(2018,7,16,10,0,0))};
            List<PlayerScoreRecord> actural = playerScoreIO.GetPlayerScores(p => p.SelectedGame.SelectedStages.Diffculity == SelectedStages.StageDiffculity.Normal);

            Assert.That(actural.SequenceEqual(excepted));
        }
        [Test]
        public void GetAllPlayerScoreRecordFromEmptyFolderTest()
        {
            playerScoreIO.DeleteAllPlayerScore();
            List<PlayerScoreRecord> records = playerScoreIO.GetAllPlayerRecord();

            OneTimeTearDown();
            OneTimeSetUp();

            Assert.That(records.Count == 0);
        }


    }
}