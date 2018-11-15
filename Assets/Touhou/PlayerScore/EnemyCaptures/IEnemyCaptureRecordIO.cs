using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touhou.PlayerScore.EnemyCaptures
{
    interface IEnemyCaptureRecordIO
    {
        EnemysCapturesRecords GetCaptureEnemyComponentsRecord();


        EnemyCaptureResult GetEnemyCaptureResult(Predicate<EnemyCaptureResult> match);
        List<EnemyCaptureResult> GetEnemyCapturetResults(Func<EnemyCaptureResult, bool> matches);

        void SaveCapturedEnemyComponentRecord(EnemyCaptureResult enemyCapturetResult);

        void SaveCapturedEnemyComponentsRecord(EnemysCapturesRecords record);
        void SaveCapturedEnemyComponentsRecords(EnemysCapturesRecords record);

        void DeleteCapturedComponentRecord();
        void LoadEnemysCapturesRecords();
    }
}
