using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Touhou.Core.Enemy.Controller
{
    public class BulletPattern : EnemyComponentBase, IBulletPattern, IEnemyComponentTimerHealth
    {
        [SerializeField]
        public BulletCatainer BulletPatternData;
        public IEnemyHealth Health { get; set; }
        public IEnemyCountDownTimer Timer { get; set; }


        public override event EventHandler<EventArgs> OnEnemyConditionChange;
        public override event EventHandler<EventArgs> OnEnemyFinished;
        public override event EventHandler<EventArgs> OnEnemyEnd;


        public override IEnemyComponent IntializeEnemyComponent()
        {
            GameObject thisObj = Instantiate(gameObject);
            return thisObj.GetComponent<IEnemyComponent>();
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
            Health = BulletPatternData.Health;
            Timer = BulletPatternData.Timer;
        }
        void subscribeEvents()
        {
            Health.OnHealthReachZero += OnEnemyFinished;
            Timer.OnTimeReachZero += OnEnemyFinished;

            Health.OnHealthReachZero += onBulletPatternOver;
            Timer.OnTimeReachZero += onBulletPatternOver;
        }
        void onBulletPatternOver(object sender, EventArgs e)
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
            endBulletPatternEvents();
            unScribeEvents();


            if (this != null)
            {
                Destroy(gameObject);
            }


        }

        void endBulletPatternEvents()
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