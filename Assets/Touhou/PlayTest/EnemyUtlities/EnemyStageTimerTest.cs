using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Touhou.Core.Enemy;
using System;

namespace Touhou.PlayTest.EnemyUtlities
{

    public class EnemyStageTimerTest
    {
        EnemyCountDownTimer enemyCountDownTimer;

        [UnityTest]
        public IEnumerator EnemyStageTimerPlayTest()
        {

            enemyCountDownTimer = new GameObject().AddComponent<EnemyCountDownTimer>();
            enemyCountDownTimer.IntializeCountDownTimer(3);

            bool isReachZero = false;
            enemyCountDownTimer.OnTimeReachZero += new EventHandler<EventArgs>(delegate (object sender, EventArgs args)
            {
                isReachZero = true;
            });

            enemyCountDownTimer.IntializeCountDownTimer(3f);
            enemyCountDownTimer.StartTimer();

            // Use the Assert class to test conditions.
            // yield to skip a frame
            yield return new WaitForSecondsRealtime(3.05f);

            Assert.That(isReachZero);
        }


    }

}
