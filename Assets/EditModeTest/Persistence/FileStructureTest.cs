using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Touhou.IO.PlayerScore.Score;
using System.IO;

public class FileStructureTest
{

        [Test]
        public void CreateFileStructureTest()
        {
            FileStructure.CreateGameDataPersistenceFileStructure();
            Debug.Log(Application.persistentDataPath);

            Assert.IsTrue(Directory.Exists(FileStructure.PlayerReplayPersistencePath) && 
                          Directory.Exists(FileStructure.SettingPersistencePath) && 
                          Directory.Exists(FileStructure.PlayerScorePersistencePath));
        }
        [Test]
        public void DeleteFileStructureTest()
        {
            FileStructure.CreateGameDataPersistenceFileStructure();
            FileStructure.DeleteAllPersistenceFiles();

            Assert.That(Directory.Exists(FileStructure.PlayerReplayPersistencePath) && 
                        Directory.Exists(FileStructure.SettingPersistencePath) && 
                        Directory.Exists(FileStructure.PlayerScorePersistencePath), Is.False);

        }

    
}
