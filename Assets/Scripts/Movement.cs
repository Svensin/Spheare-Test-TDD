using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	float speed = 100f;
	public bool isCollided;
	Transform transformSphere;
	//Rigidbody rigidbody;
	public GameObject objChild;
	// Start is called before the first frame update
	void Start ( )
	{
		isCollided = false;
		transformSphere = transform;
		objChild = transform.GetChild( 0 ).gameObject;
		//rigidbody = gameObject.GetComponent<Rigidbody>();
	}



    // Update is called once per frame
    void Update ( )
	{
		if ( Input.GetKey(KeyCode.D)) {
			MoveRight();
		}
		else if (Input.GetKey(KeyCode.A)) {
			MoveLeft();
		}

		if (Input.GetKey(KeyCode.W)) {
			MoveUp();
		} 
		else if (Input.GetKey(KeyCode.S)) {
			MoveDown();
		}

	}

	public void MoveUp ( )
	{
		if (!isCollided)
        {
			transform.Translate(Vector3.forward * Time.deltaTime);

			//rigidbody.velocity = Vector3.forward;
			objChild.transform.Rotate(Vector3.right * Time.deltaTime * speed, Space.World);
		}
		 
	}

	public void MoveDown ( )
	{
		if (!isCollided)
		{
			transform.Translate(-Vector3.forward * Time.deltaTime);
			//rigidbody.velocity = -Vector3.forward;
			objChild.transform.Rotate(-Vector3.right * Time.deltaTime * speed, Space.World);
		}
		
	}

	public void MoveLeft ( )
	{	
		if (!isCollided)
        {
			transform.Translate(Vector3.left * Time.deltaTime);
			//rigidbody.velocity = Vector3.left;
			objChild.transform.Rotate(Vector3.forward * Time.deltaTime * speed, Space.World);
		}
		
	}

	public void MoveRight ( )
	{
		if (!isCollided)
		{
			transform.Translate(Vector3.right * Time.deltaTime);
			//rigidbody.velocity = Vector3.right;
			objChild.transform.Rotate(-Vector3.forward * Time.deltaTime * speed, Space.World);
		}
		
	}


}
