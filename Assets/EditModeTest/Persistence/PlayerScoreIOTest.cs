using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Touhou.Core.Enemy;
using Touhou.Core.Player.Data;
using Touhou.IO.PlayerScore.Score;
using Touhou.PlayerScore.Score;

namespace PersistenceTest
{
    public class PlayerScoreIOTest
    {

        [SetUp]
        public void SetUp()
        {
            //Prepare persistence file structure by recreate it
            FileStructure.DeleteAllPersistenceFiles();
            FileStructure.CreateGameDataPersistenceFileStructure();
        }
        [TearDown]
        public void TearDown()
        {
            FileStructure.DeleteAllPersistenceFiles();
        }

        [Test]
        public void SavePlayerScoreTest()
        {



            PlayerScoreIO playerScoreIO = new PlayerScoreIO();

            playerScoreIO.SavePlayerScore(new PlayerScoreRecord(
                                          new PlayerScore(1000, 320, PlayerScore.Stage.Stage4, 0.32f),
                                          new SelectedGame(new SelectedCharacter(0, 1), new SelectedStages(0, SelectedStages.StageDiffculity.Easy)),
                                          "foo-bar", DateTime.Now));

            DirectoryInfo playerRecordDirectory = new DirectoryInfo(FileStructure.PlayerScorePersistencePath);
            FileInfo[] record = playerRecordDirectory.GetFiles();

            Assert.That(record.Length == 1);


        }
        [Test]
        public void GetAllPlayerScoreTest()
        {


            PlayerScoreIO playerScoreIO = new PlayerScoreIO();

            playerScoreIO.SavePlayerScore(new PlayerScoreRecord(
                                          new PlayerScore(1000, 320, PlayerScore.Stage.Stage4, 0.32f),
                                          new SelectedGame(new SelectedCharacter(0, 1), new SelectedStages(0, SelectedStages.StageDiffculity.Easy)),
                                          "foo", DateTime.Now));

            playerScoreIO.SavePlayerScore(new PlayerScoreRecord(
                                          new PlayerScore(1000, 320, PlayerScore.Stage.Stage4, 0.32f),
                                          new SelectedGame(new SelectedCharacter(0, 1), new SelectedStages(0, SelectedStages.StageDiffculity.Easy)),
                                          "bar", DateTime.Now));
        }

    }

}