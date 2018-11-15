using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Touhou.Core.Enemy
{
    public class Stage : SerializedMonoBehaviour
    {
        [NonSerialized, OdinSerialize]
        public StageCatainer StageData;
        public List<IEnemyComponent> Enemys => StageData.StageComponents;
        public StageID StageID => StageData.StageID;


        public IEnemyComponent CurrentRunningEnemy { get; private set; }
        public int CurrentRunningEnemyIndex { get; set; }

        public event EventHandler<EventArgs> OnStageOver;
        public event EventHandler<EventArgs> OnEnemyChange;
        public event EventHandler<EventArgs> OnStageEnded;


        public IStage InstiatiateStage()
        {
            GameObject thisObject = Instantiate(gameObject);
            return thisObject.GetComponent<IStage>();
        }
        public void ActiveStage()
        {
            CurrentRunningEnemyIndex = 0;
            CurrentRunningEnemy = spwenEnemy(CurrentRunningEnemyIndex);
            CurrentRunningEnemy.OnEnemyFinished += continueStage;
            CurrentRunningEnemy.OnEnemyFinished += OnEnemyChange;
            CurrentRunningEnemy.ActiveEnemyComponent();

        }
        public void PauseStage()
        {
            CurrentRunningEnemy?.PauseEnemyComponentExcution();
        }

        public void UnPauseStage()
        {
            CurrentRunningEnemy?.UnPauseEnemyComponentExcution();
        }
        public void DeactiveStage()
        {
            OnStageEnded?.Invoke(this, new EventArgs());
            Destroy(gameObject);
        }


        void continueStage(object sender, EventArgs e)
        {
            CurrentRunningEnemy.OnEnemyFinished -= OnEnemyChange;
            CurrentRunningEnemy.OnEnemyFinished -= continueStage;
            CurrentRunningEnemyIndex++;

            if (CurrentRunningEnemyIndex > Enemys.Count - 1)
            {

                OnStageOver?.Invoke(this, new EventArgs());
            }
            else
            {

                CurrentRunningEnemy = spwenEnemy(CurrentRunningEnemyIndex);
                CurrentRunningEnemy.OnEnemyFinished += continueStage;
                CurrentRunningEnemy.OnEnemyFinished += OnEnemyChange;
                CurrentRunningEnemy.ActiveEnemyComponent();

            }
        }

        IEnemyComponent spwenEnemy(int enemyIndex)
        {
            return Enemys[enemyIndex].IntializeEnemyComponent();
        }

    }
}
