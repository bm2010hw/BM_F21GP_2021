using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    void OnTriggerEnter()
    {
        //If player touches the endTrigger let the gameManager handle the complete function
        FindObjectOfType<GameManager>().CompleteLevel();
    }
}
