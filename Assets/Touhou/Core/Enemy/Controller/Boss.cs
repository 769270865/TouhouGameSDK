using Sirenix.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Touhou.Core.Enemy.Controller
{
    public class Boss : EnemyComponentBase,IBoss
    {
        [OdinSerialize, NonSerialized]
        public BossCatainer BossData;
        public string BossName => BossData.BossName;
        public int TotalSpellCount => BossData.SpellCount;
        public List<IEnemyComponent> BossComponents => BossData.BossComponent;

        public int SpellLeft { get; private set; }
        public IEnemyComponent CurrentEnemy { get; private set; }
        public int CurrentEnenmyIndex { get; private set; }


        public override event EventHandler<EventArgs> OnEnemyConditionChange;
        public override event EventHandler<EventArgs> OnEnemyFinished;
        public override event EventHandler<EventArgs> OnEnemyEnd;

        public override IEnemyComponent IntializeEnemyComponent()
        {
            GameObject thisObject = Instantiate(gameObject);
            return thisObject.GetComponent<IEnemyComponent>();
        }


        public override void ActiveEnemyComponent()
        {

            SpellLeft = TotalSpellCount;

            CurrentEnenmyIndex = 0;

            CurrentEnemy = spawnEnemy(CurrentEnenmyIndex);
            CurrentEnemy.OnEnemyFinished += continueBoss;
            CurrentEnemy.ActiveEnemyComponent();

        }

        IEnemyComponent spawnEnemy(int enemyIndex)
        {
            return BossComponents[enemyIndex].IntializeEnemyComponent();
        }



        void continueBoss(object sender, EventArgs args)
        {
            CurrentEnenmyIndex++;
            CurrentEnemy.OnEnemyFinished -= continueBoss;
            CurrentEnemy.DeactiveEnemyComponent();

            if (CurrentEnenmyIndex > BossComponents.Count - 1)
            {

                OnEnemyFinished?.Invoke(this, new EventArgs());

            }
            else
            {
                continueToNextEnemy();
            }

            OnEnemyConditionChange?.Invoke(this, new EventArgs());

        }


        private void continueToNextEnemy()
        {
            CurrentEnemy = spawnEnemy(CurrentEnenmyIndex);
            CurrentEnemy.OnEnemyFinished += continueBoss;

            if (CurrentEnemy is SpellCard)
            {
                SpellLeft--;
            }

            CurrentEnemy.ActiveEnemyComponent();
        }
        public override void PauseEnemyComponentExcution()
        {
            CurrentEnemy.PauseEnemyComponentExcution();
        }
        public override void UnPauseEnemyComponentExcution()
        {
            CurrentEnemy.UnPauseEnemyComponentExcution();
        }
        public override void DeactiveEnemyComponent()
        {
            endBossEvents();
            unsubscribeEvents();
            Destroy(gameObject);
        }
        void endBossEvents()
        {
            if (OnEnemyEnd != null)
            {
                OnEnemyEnd(this, new EventArgs());
            }
        }
        void unsubscribeEvents()
        {
            OnEnemyEnd = null;
            OnEnemyFinished = null;
        }
    }
}
