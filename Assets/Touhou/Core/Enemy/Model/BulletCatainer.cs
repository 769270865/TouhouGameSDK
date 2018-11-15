using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Touhou.Core.Enemy
{
    [Serializable]
    public class BulletCatainer
    {
        [SerializeField]
        float componentTotalTime;
        public float ComponentTotalTime => componentTotalTime;

        [SerializeField]
        GameObject EnemyTimer;
        public IEnemyCountDownTimer Timer
        {
            get
            {
                IEnemyCountDownTimer timer = GameObject.Instantiate(EnemyTimer).GetComponent<IEnemyCountDownTimer>();
                timer.IntializeCountDownTimer(ComponentTotalTime);
                return timer;
            }
        }

        [SerializeField]
        int ComponentHealth;
        public IEnemyHealth Health => new EnemyHealth(ComponentHealth);



        [SerializeField]
        int[] bulletTypesHealthDamage;
        public int[] BulletTypesHealthDamage => bulletTypesHealthDamage;
    }

}


	
