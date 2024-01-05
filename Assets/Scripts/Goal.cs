using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Goal : MonoBehaviour
{
    public int playerNumber;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            if (playerNumber == 1)
            {
                ScoreCounter.player1Score++;
            }
            else if (playerNumber == 2)
            {
                ScoreCounter.player2Score++;
            }
        }
    }
}
