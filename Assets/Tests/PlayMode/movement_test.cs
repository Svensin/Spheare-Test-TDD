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
        

		private void Reset ( )
		{
			if ( camera == null ) {
				camera = GameObject.Instantiate( Resources.Load( "Main Camera" ) as GameObject );
			}

			sphere = GameObject.Instantiate( Resources.Load("PlayerPrefab") as GameObject );
			child = sphere.transform.GetChild( 0 ).gameObject;
			sphere.GetComponent<Movement>().objChild = child;
		}

	

		// A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
		// `yield return null;` to skip a frame.
		[UnityTest]
        public IEnumerator movement_testMovesUp()
        {
			Reset();
			sphere.GetComponent<Movement>().MoveUp();
			// Use the Assert class to test conditions.
			// Use yield to skip a frame.
			Debug.Log( "MovesUp" );
			yield return new WaitForSeconds(0.1f);

			Assert.Greater(child.transform.rotation.x, 0);
			Assert.Greater( sphere.transform.position.z, 0 );
        }

		[UnityTest]
		public IEnumerator movement_testMovesDown ( )
		{
			Reset();
			sphere.GetComponent<Movement>().MoveDown();
			// Use the Assert class to test conditions.
			// Use yield to skip a frame.
			Debug.Log("MovesDown");
			yield return new WaitForSeconds(0.1f);

			Assert.Less( child.transform.rotation.x, 0 );
			Assert.Less( sphere.transform.position.z, 0 );
		}

		[UnityTest]
		public IEnumerator movement_testMovesRight( )
		{
			Reset();

			sphere.GetComponent<Movement>().MoveRight();
			// Use the Assert class to test conditions.
			// Use yield to skip a frame.
			Debug.Log( "MovesRight" );
			yield return new WaitForSeconds(0.1f);

			Assert.Less( child.transform.rotation.z, 0 );
			Assert.Greater( sphere.transform.position.x, 0 );
		}

		[UnityTest]
		public IEnumerator movement_testMovesLeft()
		{
			Reset();
			sphere.GetComponent<Movement>().MoveLeft();
			// Use the Assert class to test conditions.
			// Use yield to skip a frame.
			Debug.Log( "MovesLeft" );
			yield return new WaitForSeconds(0.1f);

			Assert.Greater( child.transform.rotation.z, 0 );
			Assert.Less( sphere.transform.position.x, 0 );
		}
	}
}
