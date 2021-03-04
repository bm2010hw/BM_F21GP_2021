using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateScript : MonoBehaviour
{
    public GameObject enemy;

    void OnTriggerEnter()
    {
        //when the player enter this trigger it will activate the chasing script of the corresponding enemy
        enemy.GetComponent<npcController>().enabled = true;
    }
}
