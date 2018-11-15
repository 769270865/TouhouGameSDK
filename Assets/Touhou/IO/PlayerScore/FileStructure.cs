using System;
using System.IO;
using System.Threading;
using UnityEngine;

namespace Touhou.IO.PlayerScore.Score
{
    public static class FileStructure
    {
        static string persistencePath = Application.persistentDataPath;

        public static string SettingPersistencePath
        {
            get { return persistencePath + "/Settings"; }
        }
        public static string PlayerScorePersistencePath
        {
            get { return persistencePath + "/PlayerScores"; }
        }
        public static string PlayerReplayPersistencePath
        {
            get { return persistencePath + "/Replays"; }
        }
        public static string CapturedEnemyComponentRecordPath
        {
            get { return persistencePath + "/CapturedEnemyComponentRecord"; }
        }

        public static void CreateGameDataPersistenceFileStructure()
        {
            CreateSettingPersistenceFolder();
            CreatePlayerReplayFolder();
            CreatePlayerScorePersistenceFolder();
            CreateCapturedEnemyComponentRecordFolder();
        }

        public static void CreateSettingPersistenceFolder()
        {
            if (!Directory.Exists(SettingPersistencePath))
            {
                try
                {
                    Directory.CreateDirectory(SettingPersistencePath);
                }
                catch (Exception e)
                {

                    Debug.Log(string.Format("Create Setting Persistence Folder failed: {0}", e.ToString()));
                }
            }
        }
        public static void CreatePlayerScorePersistenceFolder()
        {
            if (!Directory.Exists(PlayerScorePersistencePath))
            {
                try
                {
                    Directory.CreateDirectory(PlayerScorePersistencePath);
                }
                catch (Exception e)
                {

                    Debug.Log(string.Format("Create Score Persistence Folder failed: {0}", e.ToString()));
                }
            }
        }
        public static void CreatePlayerReplayFolder()
        {
            if (!Directory.Exists(PlayerReplayPersistencePath))
            {
                try
                {
                    Directory.CreateDirectory(PlayerReplayPersistencePath);
                }
                catch (Exception e)
                {

                    Debug.Log(string.Format("Create Replay Persistence Folder failed: {0}", e.ToString()));
                }
            }
        }
        public static void CreateCapturedEnemyComponentRecordFolder()
        {
            if (!Directory.Exists(CapturedEnemyComponentRecordPath))
            {
                try
                {
                    Directory.CreateDirectory(CapturedEnemyComponentRecordPath);
                }
                catch (Exception e)
                {

                    Debug.Log(string.Format("Create Captured Enemy Component Record Folder failed:{0}", e.ToString()));
                }
            }
        }
        public static void DeleteAllPersistenceFiles()
        {
            DeletePlayerScorePersistenceFiles();
            DeleteSettingPersistenceFiles();
            DeleteReplayPersistenceFolder();
            DeleteCapturedEnemyComponentsRecord();
        }
        public static void DeletePlayerScorePersistenceFiles()
        {
            if (Directory.Exists(PlayerScorePersistencePath))
            {
                try
                {
                    Directory.Delete(PlayerScorePersistencePath, true);
                }
                catch (Exception e)
                {
                    
                    Debug.Log(string.Format("Delete Score Persistence Folder failed : {0}", e.ToString()));
                }
            }
        }
        public static void DeleteSettingPersistenceFiles()
        {
            if (Directory.Exists(SettingPersistencePath))
            {
                try
                {
                    Directory.Delete(SettingPersistencePath, true);
                }
                catch (Exception e)
                {
                   
                    Debug.Log(string.Format("Delete setting Persistence Folder failed : {0}", e.ToString()));
                }
            }
        }
        public static void DeleteReplayPersistenceFolder()
        {
            if (Directory.Exists(PlayerReplayPersistencePath))
            {
                try
                {
                    Directory.Delete(PlayerReplayPersistencePath, true);
                }
                catch (Exception e)
                {

                    Debug.Log(string.Format("Delete replay Persistence Folder failed : {0}", e.ToString()));
                }
            }
        }
        public static void DeleteCapturedEnemyComponentsRecord()
        {
            if (Directory.Exists(CapturedEnemyComponentRecordPath))
            {
                try
                {
                    Directory.Delete(CapturedEnemyComponentRecordPath, true);
                }
                catch (Exception e)
                {

                    Debug.Log(string.Format("Delete Captured Enemy Component Record folder failed : {0}", e.ToString()));
                }
            }
        }
    }
}