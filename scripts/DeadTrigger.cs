using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadTrigger : MonoBehaviour
{
    public movements movement;

    void OnTriggerEnter()
    {
        //if player enter a dead trigger tell the gameManager to handle it and make sure the player can't move
        movement.enabled = false;

        FindObjectOfType<GameManager>().EndGame();
    }
}
