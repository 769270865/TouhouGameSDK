using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Touhou.PlayTest
{
    public static class DataInjectorTestHelerMethod
    {
        public static GameObject GetTestBulletPattern(int TestBulletPatternNumber)
        {
            if (TestBulletPatternNumber <= 3 && TestBulletPatternNumber > 0)
            {
                return GameObject.Instantiate(Resources.Load<GameObject>($"TestResources/EnemyComponentPrefab/TestBulletPattern{TestBulletPatternNumber}"));
            }
            else
            {
                throw new ArgumentException("Only 3 TestBulletPattern Exist!");
            }

        }
        public static GameObject GetTestMockkBulletPattern(int TestMockBulletPatternNumber)
        {
            if (TestMockBulletPatternNumber <= 3 && TestMockBulletPatternNumber > 0)
            {
                return GameObject.Instantiate(Resources.Load<GameObject>($"TestResource/EnemyComponentMocksPrefab/TestMockBulletPattern{TestMockBulletPatternNumber}"));

            }
            else
            {
                throw new ArgumentException("Only 3 TestMockBulletPattern Exist!");
            }
        }

        public static GameObject GetTestSpellCard(int TestSpellCardNumber)
        {
            if (TestSpellCardNumber <= 3 && TestSpellCardNumber > 0)
            {
                return GameObject.Instantiate(Resources.Load<GameObject>($"TestResources/EnemyComponentPrefab/TestSpellCard{TestSpellCardNumber}"));
            }
            else
            {
                throw new ArgumentException("Only 3 TestSpellCard Exist!");
            }

        }
        public static GameObject GetTestMockSpellCard(int TestMockSpellCardNumber)
        {
            if (TestMockSpellCardNumber <= 3 && TestMockSpellCardNumber > 0)
            {
                return GameObject.Instantiate(Resources.Load<GameObject>($"TestResource/EnemyComponentMocksPrefab/TestMockSpellCard{TestMockSpellCardNumber}"));
            }
            else
            {
                throw new ArgumentException("Only 3 TestMockSpellCard Exist!");
            }
        }

        public static GameObject GetTestBoss(int TestBossNumber)
        {
            if (TestBossNumber <= 3 && TestBossNumber > 0)
            {
                return GameObject.Instantiate(Resources.Load<GameObject>($"TestResources/EnemyComponentPrefab/TestBoss{TestBossNumber}"));
            }
            else
            {
                throw new ArgumentException("Only 3 TestBoss Exist!");
            }

        }
        public static GameObject GetTestMockBoss(int TestMockBossNumber)
        {
            if (TestMockBossNumber <= 3 && TestMockBossNumber > 0)
            {
                return GameObject.Instantiate(Resources.Load<GameObject>($"TestResources/EnemyComponentMocksPrefab/TestMockBoss{TestMockBossNumber}"));
            }
            else
            {
                throw new ArgumentException("Only 3 TestMockBoss Exist");
            }
        }

        public static GameObject GetTestStage(int TestStageNumbner)
        {
            if (TestStageNumbner <= 3 && TestStageNumbner > 0)
            {
                return Resources.Load<GameObject>($"TestResources/EnemyComponentPrefab/TestStage{TestStageNumbner}");
            }
            else
            {
                throw new ArgumentException("Only 3 TestStage Exist!");
            }
        }
        public static GameObject GetTestMockStage(int TestMockStageNumber)
        {
            if (TestMockStageNumber <= 3 && TestMockStageNumber > 0)
            {
                return Resources.Load<GameObject>($"TestResources/EnemyComponentMocksPrefab/TestMockStage{TestMockStageNumber}");
            }
            else
            {
                throw new ArgumentException("Only 3 TestMockStageExist!");
            }
        }

        public static GameObject GetTestMainStage(int TestMockMainStageNumber)
        {
            if (TestMockMainStageNumber <= 2 && TestMockMainStageNumber > 0)
            {
                return Resources.Load<GameObject>($"TestResources/EnemyComponentMocksPrefab/TestMockMainStage{TestMockMainStageNumber}");
            }
            else
            {
                throw new ArgumentException("Only 3 TestMockMainStageExist!");
            }
        }


        public static GameObject GetTimer()
        {
            return Resources.Load<GameObject>("TestResources/EnemyComponentPrefab/TestTimer");
        }
    }
}

    

