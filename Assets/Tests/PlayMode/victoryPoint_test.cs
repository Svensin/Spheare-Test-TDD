using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class victoryPoint_test
    {
        GameObject player;
        VictoryPoint point;
        GameObject enemy;



        [UnityTest]
        public IEnumerator victoryPoint_ifPlayerAtVictoryPoint_assertPlayerWon()
        {
            var victory = GameObject.Instantiate(Resources.Load("WinPoint") as GameObject);
            player = GameObject.Instantiate(Resources.Load("Player") as GameObject, victory.transform.position, Quaternion.identity);
            //enemy = GameObject.Instantiate(Resources.Load("Enemy") as GameObject);

            point = victory.GetComponent<VictoryPoint>();

            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();

            Assert.True(point.isPlayer);
            Assert.False(point.isEnemy);

            GameObject.Destroy(victory);
            GameObject.Destroy(player);
        }

        [UnityTest]
        public IEnumerator victoryPoint_ifPlayerAndEnemyAtVictoryPoint_assertPlayerLost()
        {
            var victory = GameObject.Instantiate(Resources.Load("WinPoint") as GameObject);
            player = GameObject.Instantiate(Resources.Load("Player") as GameObject, victory.transform.position, Quaternion.identity);
            enemy = GameObject.Instantiate(Resources.Load("Enemy") as GameObject, victory.transform.position + Vector3.forward*0.6f, Quaternion.identity);

            point = victory.GetComponent<VictoryPoint>();

            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();

            Assert.True(point.isPlayer);
            Assert.True(point.isEnemy);

            GameObject.Destroy(victory);
            GameObject.Destroy(player);
            GameObject.Destroy(enemy);
        }


        [UnityTest]
        public IEnumerator victoryPoint_ifEnemyAtVictoryPoint_assertPlayerLost()
        {
            var victory = GameObject.Instantiate(Resources.Load("WinPoint") as GameObject);         
            enemy = GameObject.Instantiate(Resources.Load("Enemy") as GameObject, victory.transform.position + Vector3.forward * 0.6f, Quaternion.identity);

            point = victory.GetComponent<VictoryPoint>();

            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();

            Assert.False(point.isPlayer);
            Assert.True(point.isEnemy);

            GameObject.Destroy(victory);      
            GameObject.Destroy(enemy);
        }
    }
}
