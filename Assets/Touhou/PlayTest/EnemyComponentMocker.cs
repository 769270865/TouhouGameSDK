using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections;
using System.Collections.Generic;
using Touhou.Core.Enemy;
using UnityEngine;


namespace Touhou.PlayTest.EnemyUtlities
{
    public class EnemyComponentMocker : SerializedMonoBehaviour
    {
        [OdinSerialize]
        public IBulletPattern TestBulletPattern;
        [OdinSerialize]
        public ISpellCard TestSpellCard;
        public float TestEnemyComponentLifeTime;
        public bool isDefeatedMock;


        // Use this for initialization
        void Start()
        {
            StartCoroutine("TestingProcess");
        }

        IEnumerator TestingProcess()
        {
            if (isDefeatedMock)
            {
                yield return new WaitForSecondsRealtime(TestEnemyComponentLifeTime / 2 + Random.Range(+0.5f, -0.5f));
                if (TestBulletPattern != null)
                {
                    TestBulletPattern.Health.DecreseHealth(100);
                }
                else if (TestSpellCard != null)
                {
                    TestSpellCard.Health.DecreseHealth(100);
                }

            }
            else
            {
                yield return new WaitForSecondsRealtime(TestEnemyComponentLifeTime / 2 + Random.Range(+0.5f, -0.5f));
                if (TestBulletPattern != null)
                {
                    TestBulletPattern.Health.DecreseHealth(50);
                }
                else if (TestSpellCard != null)
                {
                    TestSpellCard.Health.DecreseHealth(50);
                }
            }
        }



    }
}


