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
        // A Test behaves as an ordinary method
        [Test]
        public void collisionDetector_testSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator collisionDetector_whenSpheresCollideFromFront_thenStops()
        {
            Arrange(Vector3.forward);

            var ray = new Ray(player.transform.position, player.transform.forward);
            RaycastHit hit;
            while (!Physics.Raycast(ray, out hit, playerCollider.radius))
            {

                movementScript.MoveUp();
                ray = new Ray(player.transform.position, player.transform.forward);
                yield return new WaitForEndOfFrame();
            }

            var lastPos = player.transform.position;



            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            //Assert.True(movementScript.isCollided);

            Assert.LessOrEqual(System.Math.Round(player.transform.position.z, 1)
                , System.Math.Round(lastPos.z));

            Delete();
        }


        [UnityTest]
        public IEnumerator collisionDetector_whenSpheresCollideFromBack_thenStops()
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
            //Assert.True(movementScript.isCollided);

            Assert.GreaterOrEqual(System.Math.Round(player.transform.position.z, 1)
                , System.Math.Round(lastPos.z));

            Delete();
        }

        private void Delete()
        {
            GameObject.Destroy(wall);
            GameObject.Destroy(player);
        }

        [UnityTest]
        public IEnumerator collisionDetector_whenSpheresCollideFromRight_thenStops()
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
            //Assert.True(movementScript.isCollided);

            Assert.LessOrEqual(System.Math.Round(player.transform.position.x, 1)
                , System.Math.Round(lastPos.x));

            Delete();
        }

        [UnityTest]
        public IEnumerator collisionDetector_whenSpheresCollideFromLeft_thenStops()
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
            //Assert.True(movementScript.isCollided);

            Assert.GreaterOrEqual(System.Math.Round(player.transform.position.x, 1)
                , System.Math.Round(lastPos.x));

            Delete();
        }

        private void Arrange(Vector3 wallDirection, float rotation = default)
        {
            if (camera == null)
            {
                camera = GameObject.Instantiate(Resources.Load("Main Camera") as GameObject);
            }

            player = GameObject.Instantiate(Resources.Load("PlayerPrefab") as GameObject);
            playerCollider = player.GetComponent<SphereCollider>();
            movementScript = player.GetComponent<Movement>();

            wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
            wall.transform.position += wallDirection * 2;
            if (rotation != default)
            {
                wall.transform.Rotate(new Vector3(0,rotation,0));
            }
            wall.transform.localScale = new Vector3(10, 10, 1);
            wall.AddComponent<Rigidbody>().useGravity = false;
        }
    }
}
