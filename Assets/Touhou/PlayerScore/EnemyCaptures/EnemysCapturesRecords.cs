using System;
using System.Collections.Generic;
using System.Linq;

namespace Touhou.PlayerScore.EnemyCaptures
{
    public class EnemysCapturesRecords
    {
        public List<EnemyCaptureResult> Records { get; private set; }

        public EnemysCapturesRecords(List<EnemyCaptureResult> record)
        {
            Records = record;
            if (isDuplicateExist())
            {
                throw new ArgumentException("A duplicated EnemyComponentID number exist!");
            }

            Records.OrderBy(p => p.CapturedComponentID.ComponentID);
        }
        bool isDuplicateExist()
        {
            var result = Records.GroupBy(p => p.CapturedComponentID.ComponentID);
            foreach (var group in result)
            {
                if (group.Count() > 1)
                {
                    return true;
                }
            }
            return false;
        }

        public EnemyCaptureResult GetEnemyCaptureResult(Predicate<EnemyCaptureResult> match)
        {
            return Records.Find(match);
        }
        public List<EnemyCaptureResult> GetEnemyCaptureResults(Func<EnemyCaptureResult, bool> matches)
        {
            List<EnemyCaptureResult> result = Records.Where(matches).ToList();
            if (result.Count == 0)
            {
                return null;
            }
            return result;

        }
        public void AddNewRecord(EnemyCaptureResult enemyComponent)
        {
            int corrospondIndex = getCorronspondingEnemyIndex(enemyComponent);

            writeToRecords(enemyComponent, corrospondIndex);

        }

        int getCorronspondingEnemyIndex(EnemyCaptureResult record)
        {
            return Records.FindIndex(p => p.CapturedComponentID.Equals(record.CapturedComponentID));
        }

        void writeToRecords(EnemyCaptureResult enemyComponent, int corrospondIndex)
        {
            //If this type of component is in the record
            if (corrospondIndex > -1)
            {
                if (enemyComponent.CapturedComponentScore.IsScoreHigherThen(Records[corrospondIndex].CapturedComponentScore))
                {
                    Records[corrospondIndex] = enemyComponent;
                }
            }
            else
            {
                Records.Add(enemyComponent);
                Records.OrderBy(p => p.CapturedComponentID.ComponentID);
            }

        }
    }
}