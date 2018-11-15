using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Touhou.Core;
using Touhou.PlayerScore;
using Touhou.PlayerScore.Score;

namespace Touhou.IO.PlayerScore.Score
{
    public class PlayerScoreIO : IPlayerScoreIO
    {
        List<PlayerScoreRecord> playerScoreRecords;

        public PlayerScoreIO()
        {
            playerScoreRecords = GetAllPlayerRecord();

        }

        public void SavePlayerScore(PlayerScoreRecord playerScoreRecord)
        {
            string playerScoreFileName = generatePlayerScoreFileName(playerScoreRecord);

            if (!Directory.Exists(FileStructure.PlayerScorePersistencePath))
            {
                FileStructure.CreatePlayerScorePersistenceFolder();
            }
            savePlayerScore(playerScoreRecord, playerScoreFileName);

            ReloadPlayerScoresFromSave();
        }
        private void savePlayerScore(PlayerScoreRecord playerScoreRecord, string playerScoreFileName)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Path.Combine(FileStructure.PlayerScorePersistencePath , playerScoreFileName));
            bf.Serialize(file, playerScoreRecord);
            file.Close();
        }

       
        string generatePlayerScoreFileName(PlayerScoreRecord playerScoreRecord)
        {


            string fileName = $"ScoreRecord_ " +
                                $"{playerScoreRecord.PlayerName}_" +
                                $"{playerScoreRecord.RecordDate.Year}_" +
                                $"{playerScoreRecord.RecordDate.Month}_" +
                                $"{playerScoreRecord.RecordDate.Day}_" +
                                $"{playerScoreRecord.RecordDate.TimeOfDay.Ticks}.dat";

            return fileName;
        }

        public List<PlayerScoreRecord> GetAllPlayerRecord()
        {
            if (!Directory.Exists(FileStructure.PlayerScorePersistencePath))
                FileStructure.CreatePlayerScorePersistenceFolder();

            return readAllPlayerRecord();
        }
        private List<PlayerScoreRecord> readAllPlayerRecord()
        {
            DirectoryInfo playerRecordsDirectory = new DirectoryInfo(FileStructure.PlayerScorePersistencePath);
            FileInfo[] playerRecords = playerRecordsDirectory.GetFiles("*.dat");

            return deserializePlayerRecprdFiles(playerRecords);
        }
        private List<PlayerScoreRecord> deserializePlayerRecprdFiles(FileInfo[] PlayerRecordsFile)
        {
            BinaryFormatter bf = new BinaryFormatter();
            List<PlayerScoreRecord> playerScoreRecords = new List<PlayerScoreRecord>();

            for (int i = 0; i < PlayerRecordsFile.Length; i++)
            {
                FileStream file = File.Open(PlayerRecordsFile[i].FullName, FileMode.Open);
                playerScoreRecords.Add((PlayerScoreRecord)bf.Deserialize(file));
                file.Close();
            }
            return playerScoreRecords;
        }

        public PlayerScoreRecord GetPlayerScore(Predicate<PlayerScoreRecord> match)
        {
            return playerScoreRecords.Find(match);
        }

        public List<PlayerScoreRecord> GetPlayerScores(Func<PlayerScoreRecord, bool> matches)
        {
            return playerScoreRecords.Where(matches).ToList();
        }

        public void ReloadPlayerScoresFromSave()
        {
            playerScoreRecords = GetAllPlayerRecord();
        }

       
        public void DeleteAllPlayerScore()
        {
            DirectoryInfo playerRecordDirectory = new DirectoryInfo(FileStructure.PlayerScorePersistencePath);

            foreach (FileInfo playerRecordFile in playerRecordDirectory.GetFiles())
            {
                playerRecordFile.Delete();
            }
            ReloadPlayerScoresFromSave();
        }



       
    }
}
