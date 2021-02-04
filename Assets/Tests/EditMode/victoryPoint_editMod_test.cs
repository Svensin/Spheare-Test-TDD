using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class victoryPoint_editMod_test
    {
        /// <summary>
        /// Testing if ONLY Player is at the Victory Point
        /// </summary>
        [Test]
        public void victoryPoint_ifPlayerAtVictoryPoint_assertsVictory()
        {
            var victory = GameObject.Instantiate(Resources.Load("WinPoint") as GameObject);

            VictoryPoint victoryScript = victory.GetComponent<VictoryPoint>();

            victoryScript.isPlayer = true;
            victoryScript.isEnemy = false;

            victoryScript.StopGame();

            Assert.AreEqual("Player", victoryScript.winner);
        }

        /// <summary>
        /// Testing if ONLY Enemy is at the Victory Point
        /// </summary>
        [Test]
        public void victoryPoint_ifEnemyAtVictoryPoint_assertsFailure()
        {
            var victory = GameObject.Instantiate(Resources.Load("WinPoint") as GameObject);

            VictoryPoint victoryScript = victory.GetComponent<VictoryPoint>();

            victoryScript.isPlayer = false;
            victoryScript.isEnemy = true;

            victoryScript.StopGame();


            Assert.AreEqual("Enemy", victoryScript.winner);
        }

        /// <summary>
        /// Testing if BOTH Player and Enemy are at the Victory Point
        /// </summary>
        [Test]
        public void victoryPoint_ifEnemyAndPlayerAtVictoryPoint_assertsFailure()
        {
            var victory = GameObject.Instantiate(Resources.Load("WinPoint") as GameObject);

            VictoryPoint victoryScript = victory.GetComponent<VictoryPoint>();

            victoryScript.isPlayer = true;
            victoryScript.isEnemy = true;

            victoryScript.StopGame();

            Assert.AreEqual("Enemy", victoryScript.winner);
        }
    }
}