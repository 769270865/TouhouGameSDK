using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Touhou.Core.Enemy
{
    /// <summary>
    /// A count down timer that based based on Unity, to construct instiate as a GameObject
    /// </summary>
    public class EnemyCountDownTimer : MonoBehaviour, IEnemyCountDownTimer
    {
        public float CurrentTime { get; private set; }

        public float TotalTime { get; private set; }

        public event EventHandler<EventArgs> OnTimeReachZero;

        //public IUnityService UnityService;

        bool isTimerIntialized;
        bool isTimerRunning;


        void Update()
        {
            if (isTimerRunning)
            {
                runTimer();
            }
        }
        void runTimer()
        {
            if (isTimerRunning && CurrentTime > 0)
            {
                CurrentTime -= Time.deltaTime;
            }

            if (CurrentTime <= 0)
            {
                OnTimeReachZero?.Invoke(this, new EventArgs());

                StopTimer();
            }
        }


        public void IntializeCountDownTimer(float totalCountDownTime)
        {
            TotalTime = totalCountDownTime;
            CurrentTime = totalCountDownTime;
            isTimerIntialized = true;
        }


        public void StartTimer()
        {
            if (isTimerIntialized)
            {

                isTimerRunning = true;
            }
            else
            {
                throw new ArgumentException("Timer has not been intialized, use SetCountDownTimer before call StartTimer");
            }

        }

        public void StopTimer()
        {
            isTimerRunning = false;
        }
        public void PauseTimer()
        {
            isTimerRunning = false;
        }
        public void UnPauseTimer()
        {
            isTimerRunning = true;
        }
        public void TimerTearDown()
        {
            if (this != null)
            {
                Destroy(gameObject);
            }

        }

    }
}