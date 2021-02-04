using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed = 100f;
    public bool isCollided;
    Transform transformSphere;

    public GameObject objChild;
    
    void Start()
    {
        //init all the fields
        isCollided = false;
        transformSphere = transform;
        //"center" object which makes a sphere to rotate in a movement direction
        objChild = transform.GetChild(0).gameObject;
    }


    /// <summary>
    /// Checking input in Update to move player
    /// </summary>
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }

        if (Input.GetKey(KeyCode.W))
        {
            MoveUp();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            MoveDown();
        }
    }
    
    /// <summary>
    /// Method moves player forward
    /// </summary>
    public void MoveUp()
    {
        if (!isCollided)
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
            objChild.transform.Rotate(Vector3.right * Time.deltaTime * speed, Space.World);
        }
    }

    /// <summary>
    /// Method moves player backward
    /// </summary>
    public void MoveDown()
    {
        if (!isCollided)
        {
            transform.Translate(-Vector3.forward * Time.deltaTime);
            objChild.transform.Rotate(-Vector3.right * Time.deltaTime * speed, Space.World);
        }
    }

    /// <summary>
    /// Method moves player left
    /// </summary>
    public void MoveLeft()
    {
        if (!isCollided)
        {
            transform.Translate(Vector3.left * Time.deltaTime);
            objChild.transform.Rotate(Vector3.forward * Time.deltaTime * speed, Space.World);
        }
    }

    /// <summary>
    /// Method moves player right
    /// </summary>
    public void MoveRight()
    {
        if (!isCollided)
        {
            transform.Translate(Vector3.right * Time.deltaTime);
            objChild.transform.Rotate(-Vector3.forward * Time.deltaTime * speed, Space.World);
        }
    }
}