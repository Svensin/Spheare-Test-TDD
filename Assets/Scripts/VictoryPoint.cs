using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryPoint : MonoBehaviour
{
    public bool isPlayer = false;
    public bool isEnemy = false;

    public string winner = "";

    /// <summary>
    /// Checks for collision with a victory point. If a collided object has a specific tag - decide who is a winner
    /// </summary>
    /// <param name="collision"></param>
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

        Invoke("StopGame", 0.1f);
    }

    /// <summary>
    /// Stop the game if someone is at the victory point
    /// </summary>
    public void StopGame() {
        
        if (winner == string.Empty)
        {
            winner = isPlayer && !isEnemy ? "Player" : "Enemy";
            //logging the winner
            Debug.Log("Win " + winner);
        }
    }
}
