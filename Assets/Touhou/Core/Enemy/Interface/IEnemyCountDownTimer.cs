using System;

namespace Touhou.Core.Enemy
{
    public interface IEnemyCountDownTimer
    {
        float CurrentTime { get; }
        float TotalTime { get; }


        void PauseTimer();
        void UnPauseTimer();
        void IntializeCountDownTimer(float totalCountDownTime);
        void StartTimer();
        void StopTimer();
        void TimerTearDown();

        event EventHandler<EventArgs> OnTimeReachZero;

    }
}