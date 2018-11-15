using System;
using System.Collections.Generic;

namespace Touhou.Core.Enemy
{
    public interface IStage
    {
        List<IEnemyComponent> Enemys { get; }
        StageID StageID { get; }

        IEnemyComponent CurrentRunningEnemy { get; }
        int CurrentRunningEnemyIndex { get; set; }


        IStage InstiatiateStage();
        void ActiveStage();
        void PauseStage();
        void UnPauseStage();
        void DeactiveStage();



        event EventHandler<EventArgs> OnStageOver;
        event EventHandler<EventArgs> OnStageEnded;
        event EventHandler<EventArgs> OnEnemyChange;
    }
}