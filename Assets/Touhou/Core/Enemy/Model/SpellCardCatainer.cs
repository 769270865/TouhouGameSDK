using System;
using UnityEngine;

namespace Touhou.Core.Enemy
{
    [Serializable]
    public class SpellCardCatainer
    {
        [SerializeField]
        string spellCardName;
        public string SpellName => this.spellCardName;

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
        float componentTotalTime;
        public float ComponentTotalTime { get; set; }

        [SerializeField]
        int componentHealth;
        public IEnemyHealth Health => new EnemyHealth(componentHealth);


        [SerializeField]
        private int[] bulletTypesHealthDamages;
        public int[] BulletTypesHealthDamages { get; set; }


    }
}
