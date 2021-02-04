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
            sphere.GetComponent<Movement>().objChild = sphere.transform.GetChild(0).gameObject;
            GameObject cube =  GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position += Vector3.forward * 2;
            cube.transform.localScale = new Vector3(10, 10, 1);
            cube.AddComponent<Rigidbody>().useGravity = false;


            var ray = new Ray(sphere.transform.position, sphere.transform.forward);
            RaycastHit hit;
           
            float maxDistance = col.radius;
            while (!Physics.Raycast(ray, out hit, col.radius))
            {

                sphere.GetComponent<Movement>().MoveUp();
                ray = new Ray(sphere.transform.position, sphere.transform.forward);
                yield return new WaitForEndOfFrame();
            }

            Debug.Log("Colided!");

            Vector3 lastPos = sphere.transform.position;

            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
                sphere.GetComponent<Movement>().MoveUp();
                
                Assert.AreEqual(System.Math.Round(sphere.transform.position.z, 1),
                    System.Math.Round(lastPos.z, 1));

                yield return new WaitForEndOfFrame();
            
        }
    }
}
