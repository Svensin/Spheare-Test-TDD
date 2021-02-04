using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scale : MonoBehaviour
{
	Vector3 v;
	public Vector3 t;

	// Start is called before the first frame update
	private void Start()
    {
		t = transform.position;
	}

	
	// Update is called once per frame
	void Update()
    {
		Scale();
    }

	private void Scale ( )
	{
		float delta = Time.deltaTime / 2;

		if ( transform.localScale.x >  - 0.1f ) {
			transform.position = new Vector3( transform.position.x, transform.position.y + delta * 2, transform.position.z);
			transform.localScale = new Vector3( transform.localScale.x - delta, transform.localScale.y -  delta, transform.localScale.z - delta );
		} else {
			transform.localScale = v;
			transform.position = t;
		}
	}
}
