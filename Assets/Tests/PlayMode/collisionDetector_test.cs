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
        // A Test behaves as an ordinary method
        [Test]
        public void collisionDetector_testSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator collisionDetector_whenSpheresCollide_thenStops()
        {
            if (camera == null)
            {
                camera = GameObject.Instantiate(Resources.Load("Main Camera") as GameObject);
            }

            GameObject sphere = GameObject.Instantiate(Resources.Load("Sphere") as GameObject );
            SphereCollider col = sphere.GetComponent<SphereCollider>();
            Movement movementScript = sphere.GetComponent<Movement>();

            GameObject cube =  GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position += Vector3.forward * 2;
            cube.transform.localScale = new Vector3(10, 10, 1);
            cube.AddComponent<Rigidbody>().useGravity = false;


            var ray = new Ray(sphere.transform.position, sphere.transform.forward);
            RaycastHit hit;
            float maxDistance = col.radius;
            while (!Physics.Raycast(ray, out hit, col.radius))
            {

                movementScript.MoveUp();
                ray = new Ray(sphere.transform.position, sphere.transform.forward);
                yield return new WaitForEndOfFrame();
            }
             
            Assert.IsTrue(movementScript.isCollided);            
        }
    }
}
