using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ScaleTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void ScaleTestSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator ScaleTestWithEnumeratorPasses()
        {
			GameObject go = new GameObject();
			go.AddComponent<SphereCollider>();

			go.AddComponent<scale>();

			yield return new WaitUntil( ( ) => go.transform.localScale.x < 0 );
			Assert.Equals( go.transform.localScale.x, 0 );

			yield return null;
        }
    }
}
