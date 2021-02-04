using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	float speed = 100f;
	public bool isCollided;
	Transform transformSphere;
	public GameObject objChild;
	// Start is called before the first frame update
	void Start ( )
	{
		isCollided = false;
		transformSphere = transform;
		objChild = transform.GetChild( 0 ).gameObject;
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
			objChild.transform.Rotate(Vector3.right * Time.deltaTime * speed, Space.World);

		}
		
		

		 
	}

	public void MoveDown ( )
	{
		if (!isCollided)
		{
			transform.Translate(-Vector3.forward * Time.deltaTime);
			objChild.transform.Rotate(-Vector3.right * Time.deltaTime * speed, Space.World);
	
		}
		
	}

	public void MoveLeft ( )
	{	
		if (!isCollided)
        {
			transform.Translate(Vector3.left * Time.deltaTime);;
			objChild.transform.Rotate(Vector3.forward * Time.deltaTime * speed, Space.World);
			
		}
		

	}

	public void MoveRight ( )
	{
		if (!isCollided)
		{
			transform.Translate(Vector3.right * Time.deltaTime);
			objChild.transform.Rotate(-Vector3.forward * Time.deltaTime * speed, Space.World);
	
		}
	

	}


}
