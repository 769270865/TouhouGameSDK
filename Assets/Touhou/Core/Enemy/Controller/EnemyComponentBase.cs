using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System;

namespace Touhou.Core.Enemy
{
    public abstract class EnemyComponentBase : SerializedMonoBehaviour,IEnemyComponent
    {
        [OdinSerialize]
        private EnemyComponentID componentID;

        public EnemyComponentID ComponentID
        {
            get { return componentID; }
        }

        public bool IsComponentRunning { get; protected set; }

        public abstract event EventHandler<EventArgs> OnEnemyEnd;
        public abstract event EventHandler<EventArgs> OnEnemyConditionChange;
        public abstract event EventHandler<EventArgs> OnEnemyFinished;


        public abstract IEnemyComponent IntializeEnemyComponent();
        public abstract void ActiveEnemyComponent();

        public abstract void PauseEnemyComponentExcution();
        public abstract void UnPauseEnemyComponentExcution();

        public abstract void DeactiveEnemyComponent();

    }
}