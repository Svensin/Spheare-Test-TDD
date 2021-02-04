using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] Movement movement;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        movement.isCollided = true;
        Debug.Log("Has to stop moving!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
