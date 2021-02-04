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
        
        /// <summary>
        /// PlayMode test for detecting if player at the victory point
        /// </summary>
        /// <returns></returns>
        [UnityTest]
        public IEnumerator victoryPoint_ifPlayerAtVictoryPoint_assertPlayerWon()
        {
            //arranging objects
            var victory = GameObject.Instantiate(Resources.Load("WinPoint") as GameObject);
            player = GameObject.Instantiate(Resources.Load("Player") as GameObject, victory.transform.position, Quaternion.identity);
            
            point = victory.GetComponent<VictoryPoint>();

            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();

            Assert.True(point.isPlayer);
            Assert.False(point.isEnemy);

            //clearing created objects
            GameObject.Destroy(victory);
            GameObject.Destroy(player);
        }

        /// <summary>
        /// PlayMode test for detecting if player and enemy at the victory point
        /// </summary>
        /// <returns></returns>
        [UnityTest]
        public IEnumerator victoryPoint_ifPlayerAndEnemyAtVictoryPoint_assertPlayerLost()
        {
            //arranging objects
            var victory = GameObject.Instantiate(Resources.Load("WinPoint") as GameObject);
            player = GameObject.Instantiate(Resources.Load("Player") as GameObject, victory.transform.position, Quaternion.identity);
            enemy = GameObject.Instantiate(Resources.Load("Enemy") as GameObject, victory.transform.position + Vector3.forward*0.6f, Quaternion.identity);

            point = victory.GetComponent<VictoryPoint>();

            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();

            Assert.True(point.isPlayer);
            Assert.True(point.isEnemy);

            //clearing
            GameObject.Destroy(victory);
            GameObject.Destroy(player);
            GameObject.Destroy(enemy);
        }

        
        /// <summary>
        /// PlayMode test for detecting if enemy at the victory point
        /// </summary>
        /// <returns></returns>
        [UnityTest]
        public IEnumerator victoryPoint_ifEnemyAtVictoryPoint_assertPlayerLost()
        {
            //arranging objects
            var victory = GameObject.Instantiate(Resources.Load("WinPoint") as GameObject);         
            enemy = GameObject.Instantiate(Resources.Load("Enemy") as GameObject, victory.transform.position + Vector3.forward * 0.6f, Quaternion.identity);

            point = victory.GetComponent<VictoryPoint>();

            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();

            Assert.False(point.isPlayer);
            Assert.True(point.isEnemy);
            
            //clearing
            GameObject.Destroy(victory);      
            GameObject.Destroy(enemy);
        }
    }
}
