using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ScaleTest
    {
       
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator ScaleTestWithEnumeratorPasses()
        {
			GameObject.Instantiate( Resources.Load( "Main Camera" ) as GameObject );

			GameObject go = GameObject.Instantiate( Resources.Load( "Sphere" ) as GameObject );


			yield return new WaitUntil(() =>  go.transform.localScale.x < 0f );
			Assert.AreEqual( go.transform.position.x , go.GetComponent<scale>().t.x );

            yield return null;
        }
    }
}
