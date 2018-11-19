using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using Touhou.Core.Enemy;
using Touhou.Core.Enemy.Controller;
using Touhou.PlayTest;
using UnityEngine;
using UnityEngine.TestTools;

namespace Touhou.PlayTest
{
    public class EnemyComponentTest
    {
        [TearDown]
        public void TearDown()
        {

            GameObject[] allGameObject = GameObject.FindObjectsOfType<GameObject>();
            foreach (var gameObj in allGameObject)
            {
                GameObject.Destroy(gameObj);
            }
        }
        [UnityTest]
        public IEnumerator BullletPatternTimeOutTest()
        {
            bool isBulletPatternFinished = false, isBulletPatternEnded = false;
            EventHandler<EventArgs> onBulletPatternFinished = (o, s) => isBulletPatternFinished = true;
            EventHandler<EventArgs> onBulletPatternEnded = (o, s) => isBulletPatternEnded = true;

            BulletPattern bulletPattern = DataInjectorTestHelerMethod.GetTestBulletPattern(1).GetComponent<BulletPattern>();
            IEnemyComponent bulletPatternComponent = bulletPattern.IntializeEnemyComponent();
            BulletPattern bulletPatternComponentCast = (BulletPattern)bulletPatternComponent;
            bulletPatternComponentCast.OnEnemyFinished += onBulletPatternFinished;
            bulletPatternComponentCast.OnEnemyEnd += onBulletPatternEnded;
            bulletPatternComponentCast.ActiveEnemyComponent();

            yield return new WaitForSecondsRealtime(3.05f);

            bulletPatternComponentCast.DeactiveEnemyComponent();

            Debug.Log($"{isBulletPatternFinished.ToString()} {isBulletPatternEnded.ToString()}");
            Assert.That(isBulletPatternFinished && isBulletPatternEnded); ;
        }

        [UnityTest]
        public IEnumerator BulletPatternDefeatedTest()
        {
            bool isBulletPatternFinished = false;
            EventHandler<EventArgs> onBulletPatternDefeated = (o, s) => isBulletPatternFinished = true;

            BulletPattern bulletPattern = DataInjectorTestHelerMethod.GetTestBulletPattern(1).GetComponent<BulletPattern>();
            IEnemyComponent bulletPatternComponent = bulletPattern.IntializeEnemyComponent();
            BulletPattern BulletPatternFromEnemyComponent = (BulletPattern)bulletPatternComponent;
            BulletPatternFromEnemyComponent.OnEnemyFinished += onBulletPatternDefeated;
            BulletPatternFromEnemyComponent.ActiveEnemyComponent();

            BulletPatternFromEnemyComponent.Health.DecreseHealth(100);

            Assert.That(isBulletPatternFinished);

            yield return null;
        }
        [UnityTest]
        public IEnumerator SpellCardTimeOutTest()
        {
            bool isSpellCardFinished = false;
            EventHandler<EventArgs> OnSpellCardTimeOut = (o, s) => isSpellCardFinished = true;

            SpellCard testSpellCard = DataInjectorTestHelerMethod.GetTestSpellCard(2).GetComponent<SpellCard>();
            IEnemyComponent testSpellCardComponent = testSpellCard.IntializeEnemyComponent();
            SpellCard testSpellCardComponentCast = (SpellCard)testSpellCardComponent;
            testSpellCardComponentCast.OnEnemyFinished += OnSpellCardTimeOut;
            testSpellCardComponentCast.ActiveEnemyComponent();

            yield return new WaitForSecondsRealtime(3.05f);

            Assert.That(isSpellCardFinished);
        }
        [UnityTest]
        public IEnumerator SpellCardDefeatedTest()
        {
            bool isSpellCardFinished = false, isSpellCardEnded = false;
            EventHandler<EventArgs> onSpellCardFinished = (o, s) => isSpellCardFinished = true;
            EventHandler<EventArgs> onSpellCardEnded = (o, s) => isSpellCardEnded = true;

            SpellCard testSpellCard = DataInjectorTestHelerMethod.GetTestSpellCard(1).GetComponent<SpellCard>();
            IEnemyComponent testSpellCardComponent = testSpellCard.IntializeEnemyComponent();
            SpellCard testSpellCardComponentCast = (SpellCard)testSpellCardComponent;
            testSpellCardComponentCast.OnEnemyFinished += onSpellCardFinished;
            testSpellCardComponentCast.OnEnemyEnd += onSpellCardEnded;
            testSpellCardComponentCast.ActiveEnemyComponent();

            yield return new WaitForSecondsRealtime(1.5f);

            testSpellCardComponentCast.Health.DecreseHealth(100);

            testSpellCardComponentCast.DeactiveEnemyComponent();

            Debug.Log($"{isSpellCardFinished.ToString()} {isSpellCardEnded.ToString()}");
            Assert.That(isSpellCardFinished && isSpellCardEnded);
        }

        [UnityTest]
        public IEnumerator Boss_Defeated_TimeOut_Defeated_Test()
        {
            bool isBossFinished = false, isBossEnded = false;
            int enemyChangeCount = 0;

            EventHandler<EventArgs> onBossFinished = (o, s) => isBossFinished = true;
            EventHandler<EventArgs> onEnemyChange = (o, s) => enemyChangeCount++;
            EventHandler<EventArgs> onEnemyEnded = (o, s) => isBossEnded = true;

            Boss testBoss = DataInjectorTestHelerMethod.GetTestMockBoss(1).GetComponent<Boss>();
            IEnemyComponent testBossComponent = testBoss.IntializeEnemyComponent();
            Boss testBossComponentCast = (Boss)testBossComponent;

            testBossComponentCast.OnEnemyConditionChange += onEnemyChange;
            testBossComponentCast.OnEnemyFinished += onBossFinished;
            testBossComponentCast.OnEnemyEnd += onEnemyEnded;

            testBossComponentCast.ActiveEnemyComponent();

            yield return new WaitForSecondsRealtime(7.05f);

            testBossComponentCast.DeactiveEnemyComponent();

            Debug.Log($"{enemyChangeCount} {isBossFinished.ToString()}");
            Assert.That(enemyChangeCount == 3 && isBossFinished && isBossEnded);
        }
        [UnityTest]
        public IEnumerator Boss_TimeOut_Defeated_TimeOut_Test()
        {
            int enemyChangeCount = 0;
            bool isBossFinished = false, isBossEnded = false;


            EventHandler<EventArgs> onEnemyChange = (o, s) => enemyChangeCount++;
            EventHandler<EventArgs> onEnemyFinish = (o, s) => isBossFinished = true;
            EventHandler<EventArgs> onEnemyEnd = (o, s) => isBossEnded = true;

            Boss testBoss = DataInjectorTestHelerMethod.GetTestMockBoss(2).GetComponent<Boss>();
            IEnemyComponent testBossComponent = testBoss.IntializeEnemyComponent();
            Boss testBossComponentCast = (Boss)testBossComponent;

            testBossComponentCast.OnEnemyConditionChange += onEnemyChange;
            testBossComponent.OnEnemyFinished += onEnemyFinish;
            testBossComponent.OnEnemyEnd += onEnemyEnd;

            testBossComponent.ActiveEnemyComponent();

            yield return new WaitForSecondsRealtime(8.05f);

            testBossComponent.DeactiveEnemyComponent();


            Debug.Log($"{isBossFinished.ToString()} {isBossEnded.ToString()} {enemyChangeCount}");
            Assert.That(isBossFinished && isBossEnded && enemyChangeCount == 3);

        }


    }
}

