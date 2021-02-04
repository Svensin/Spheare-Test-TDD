using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class collisionDetector_test
    {
        GameObject camera;
        GameObject player;
        GameObject wall;
        SphereCollider playerCollider;
        Movement movementScript;


        /// <summary>
        /// PlayMode test if player collides with a wall from front
        /// </summary>
        /// <returns></returns>
        [UnityTest]
        public IEnumerator collisionDetector_whenPlayerCollidesFromFront_thenStops()
        {
            //arranging objects
            Arrange(Vector3.forward);

            //creating ray to detect a collision
            var ray = new Ray(player.transform.position, player.transform.forward);
            RaycastHit hit;

            //move until collide
            while (!Physics.Raycast(ray, out hit, playerCollider.radius))
            {
                movementScript.MoveUp();
                ray = new Ray(player.transform.position, player.transform.forward);
                yield return new WaitForEndOfFrame();
            }

            var lastPos = player.transform.position;

            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();

            //asserting whether object position is less of equal to a last collided
            Assert.LessOrEqual(System.Math.Round(player.transform.position.z, 1), System.Math.Round(lastPos.z));

            Delete();
        }

        /// <summary>
        /// PlayMode test if player collides with a wall from back
        /// </summary>
        /// <returns></returns>
        [UnityTest]
        public IEnumerator collisionDetector_whenPlayerCollidesFromBack_thenStops()
        {
            Arrange(-Vector3.forward);

            var ray = new Ray(player.transform.position, -player.transform.forward);
            RaycastHit hit;
            while (!Physics.Raycast(ray, out hit, playerCollider.radius))
            {
                movementScript.MoveDown();
                ray = new Ray(player.transform.position, -player.transform.forward);
                yield return new WaitForEndOfFrame();
            }

            var lastPos = player.transform.position;

            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();

            //asserting whether object position is greater of equal to a last collided
            Assert.GreaterOrEqual(System.Math.Round(player.transform.position.z, 1), System.Math.Round(lastPos.z));

            Delete();
        }

        /// <summary>
        /// Special method for clearing used game objects after a test
        /// </summary>
        private void Delete()
        {
            GameObject.Destroy(wall);
            GameObject.Destroy(player);
        }

        /// <summary>
        /// PlayMode test if player collides with a wall from right
        /// </summary>
        /// <returns></returns>
        [UnityTest]
        public IEnumerator collisionDetector_whenPlayerCollidesFromRight_thenStops()
        {
            Arrange(Vector3.right, 90f);

            var ray = new Ray(player.transform.position, player.transform.right);
            RaycastHit hit;
            while (!Physics.Raycast(ray, out hit, playerCollider.radius))
            {
                movementScript.MoveRight();
                ray = new Ray(player.transform.position, player.transform.right);
                yield return new WaitForEndOfFrame();
            }

            var lastPos = player.transform.position;


            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();

            //asserting whether object position is less of equal to a last collided
            Assert.LessOrEqual(System.Math.Round(player.transform.position.x, 1), System.Math.Round(lastPos.x));

            Delete();
        }

        /// <summary>
        /// PlayMode test if player collides with a wall from left
        /// </summary>
        /// <returns></returns>
        [UnityTest]
        public IEnumerator collisionDetector_whenSpheresCollidesFromLeft_thenStops()
        {
            Arrange(Vector3.left, 90f);

            var ray = new Ray(player.transform.position, -player.transform.right);
            RaycastHit hit;
            while (!Physics.Raycast(ray, out hit, playerCollider.radius))
            {
                movementScript.MoveLeft();
                ray = new Ray(player.transform.position, -player.transform.right);
                yield return new WaitForEndOfFrame();
            }

            var lastPos = player.transform.position;


            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();

            //asserting whether object position is greater of equal to a last collided
            Assert.GreaterOrEqual(System.Math.Round(player.transform.position.x, 1), System.Math.Round(lastPos.x));

            Delete();
        }

        /// <summary>
        /// Special method for arranging GameObjects (spawning) and setting their properties
        /// </summary>
        /// <param name="wallDirection"></param>
        /// <param name="rotation"></param>
        private void Arrange(Vector3 wallDirection, float rotation = default)
        {
            //instantiate a camera to see a scene
            if (camera == null)
            {
                camera = GameObject.Instantiate(Resources.Load("Main Camera") as GameObject);
            }

            //instantiate player
            player = GameObject.Instantiate(Resources.Load("PlayerPrefab") as GameObject);
            playerCollider = player.GetComponent<SphereCollider>();
            movementScript = player.GetComponent<Movement>();

            //instantiate wall
            wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
            wall.transform.position += wallDirection * 2;
            if (rotation != default)
            {
                wall.transform.Rotate(new Vector3(0, rotation, 0));
            }

            wall.transform.localScale = new Vector3(10, 10, 1);
            wall.AddComponent<Rigidbody>().useGravity = false;
        }
    }
}