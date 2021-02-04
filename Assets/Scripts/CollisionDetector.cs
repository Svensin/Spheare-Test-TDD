using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    Movement movement;

    // Start is called before the first frame update
    void Start()
    {
        movement = gameObject.GetComponent<Movement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        movement.isCollided = true;
    }
    
    private void OnTriggerExit(Collider other)
    {
        movement.isCollided = false;
    }
}
