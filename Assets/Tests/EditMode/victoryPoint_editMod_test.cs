﻿using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class victoryPoint_editMod_test
    {
        // A Test behaves as an ordinary method
        [Test]
        public void victoryPoint_ifPlayerAtVictoryPoint_assertsVictory()
        {
            var victory = GameObject.Instantiate(Resources.Load("WinPoint") as GameObject);

            VictoryPoint victoryScript = victory.GetComponent<VictoryPoint>();

            victoryScript.isPlayer = true;
            victoryScript.isEnemy = false;

            victoryScript.StopGame();

            Assert.AreEqual("Player",victoryScript.WIN);



            // Use the Assert class to test conditions
        }

        [Test]
        public void victoryPoint_ifEnemyAtVictoryPoint_assertsFailure()
        {
            var victory = GameObject.Instantiate(Resources.Load("WinPoint") as GameObject);

            VictoryPoint victoryScript = victory.GetComponent<VictoryPoint>();

            victoryScript.isPlayer = false;
            victoryScript.isEnemy = true;

            victoryScript.StopGame();


            Assert.AreEqual( "Enemy",victoryScript.WIN);



            // Use the Assert class to test conditions
        }


        [Test]
        public void victoryPoint_ifEnemyAndPlayerAtVictoryPoint_assertsFailure()
        {
            var victory = GameObject.Instantiate(Resources.Load("WinPoint") as GameObject);

            VictoryPoint victoryScript = victory.GetComponent<VictoryPoint>();

            victoryScript.isPlayer = true;
            victoryScript.isEnemy = true;

            victoryScript.StopGame();

            Assert.AreEqual("Enemy", victoryScript.WIN);



            // Use the Assert class to test conditions
        }

    }
}
