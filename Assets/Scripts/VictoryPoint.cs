using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryPoint : MonoBehaviour
{
    public bool isPlayer = false;
    public bool isEnemy = false;

    public string WIN = "";

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayer = true;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isEnemy = true;
        }

        Win();
    }

    public void Win() {
        
        Invoke("StopGame", 0.1f);
    }

    public void StopGame() {
        
        if (WIN == string.Empty)
        {
            WIN = isPlayer && !isEnemy ? "Player" : "Enemy";
            Debug.Log("Win " + WIN);
        }
    }

    


    // Update is called once per frame
    void Update()
    {
        
    }
}
