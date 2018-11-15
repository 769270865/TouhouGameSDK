using System;

namespace Touhou.Core.Enemy
{
    public interface IEnemyComponent
    {
        event EventHandler<EventArgs> OnEnemyEnd;
        event EventHandler<EventArgs> OnEnemyFinished;
        EnemyComponentID ComponentID { get; }

        bool IsComponentRunning { get; }

        IEnemyComponent IntializeEnemyComponent();
        void ActiveEnemyComponent();
        void PauseEnemyComponentExcution();
        void UnPauseEnemyComponentExcution();

        void DeactiveEnemyComponent();
    }
}