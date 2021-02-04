using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class movement_test
    {
        GameObject camera;
        GameObject sphere;
        GameObject child;


        /// <summary>
        /// Method for rearranging objects
        /// </summary>
        private void Reset()
        {
            //instantiate a camera
            if (camera == null)
            {
                camera = GameObject.Instantiate(Resources.Load("Main Camera") as GameObject);
            }

            //instantiate player/sphere
            sphere = GameObject.Instantiate(Resources.Load("PlayerPrefab") as GameObject);
            child = sphere.transform.GetChild(0).gameObject;
            sphere.GetComponent<Movement>().objChild = child;
        }


        /// <summary>
        /// Test for detecting if player moves forward
        /// </summary>
        /// <returns></returns>
        [UnityTest]
        public IEnumerator movement_testMovesForward()
        {
            //rearranging objects
            Reset();
            sphere.GetComponent<Movement>().MoveUp();

            Debug.Log("MovesUp");
            yield return new WaitForSeconds(0.1f);

            Assert.Greater(child.transform.rotation.x, 0);
            Assert.Greater(sphere.transform.position.z, 0);
        }

        /// <summary>
        /// Test for detecting if player moves backward
        /// </summary>
        /// <returns></returns>
        [UnityTest]
        public IEnumerator movement_testMovesBackward()
        {
            //rearranging objects
            Reset();
            sphere.GetComponent<Movement>().MoveDown();

            Debug.Log("MovesDown");
            yield return new WaitForSeconds(0.1f);

            Assert.Less(child.transform.rotation.x, 0);
            Assert.Less(sphere.transform.position.z, 0);
        }

        /// <summary>
        /// Test for detecting if player moves right
        /// </summary>
        /// <returns></returns>
        [UnityTest]
        public IEnumerator movement_testMovesRight()
        {
            //rearranging objects
            Reset();

            sphere.GetComponent<Movement>().MoveRight();

            Debug.Log("MovesRight");
            yield return new WaitForSeconds(0.1f);

            Assert.Less(child.transform.rotation.z, 0);
            Assert.Greater(sphere.transform.position.x, 0);
        }

        /// <summary>
        /// Test for detecting if player moves left
        /// </summary>
        /// <returns></returns>
        [UnityTest]
        public IEnumerator movement_testMovesLeft()
        {
            //rearranging objects
            Reset();

            sphere.GetComponent<Movement>().MoveLeft();

            Debug.Log("MovesLeft");
            yield return new WaitForSeconds(0.1f);

            Assert.Greater(child.transform.rotation.z, 0);
            Assert.Less(sphere.transform.position.x, 0);
        }
    }
}