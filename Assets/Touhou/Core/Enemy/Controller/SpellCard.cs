using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Touhou.Core.Enemy
{
    public class SpellCard :EnemyComponentBase, ISpellCard,IEnemyComponentTimerHealth
    {
        [SerializeField]
        public SpellCardCatainer SpellCardData;

        public IEnemyHealth Health { get; set; }
        public IEnemyCountDownTimer Timer { get; set; }
        public string SpellCardName { get; set; }



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
            dataInjection();
            subscribeEvents();

            Timer.StartTimer();
            Health.SetHealthActive(true);
            IsComponentRunning = true;

        }
        void dataInjection()
        {
            if (SpellCardData != null)
            {
                Health = SpellCardData.Health;
                Timer = SpellCardData.Timer;
                SpellCardName = SpellCardData.SpellName;
            }
        }
        void subscribeEvents()
        {
            Health.OnHealthReachZero += OnEnemyFinished;
            Timer.OnTimeReachZero += OnEnemyFinished;

            Health.OnHealthReachZero += onSpellCardOver;
            Timer.OnTimeReachZero += onSpellCardOver;
        }
        void onSpellCardOver(object sender, EventArgs e)
        {
            Timer.StopTimer();
            Health.SetHealthActive(false);
            IsComponentRunning = false;
        }

        public override void PauseEnemyComponentExcution()
        {
            IsComponentRunning = false;
            Health.SetHealthActive(false);
            Timer.PauseTimer();
        }
        public override void UnPauseEnemyComponentExcution()
        {
            IsComponentRunning = true;
            Health.SetHealthActive(true);
            Timer.UnPauseTimer();
        }
        public override void DeactiveEnemyComponent()
        {
            IsComponentRunning = false;
            endSpellCardActions();
            unScribeEvents();

            if (this != null)
            {
                Destroy(gameObject);
            }

        }
        void endSpellCardActions()
        {
            OnEnemyEnd?.Invoke(this, new EventArgs());
            Timer.StopTimer();
            Timer.TimerTearDown();
            Health.SetHealthActive(false);
        }
        private void unScribeEvents()
        {

            OnEnemyEnd = null;
            OnEnemyFinished = null;
        }

    }
}
