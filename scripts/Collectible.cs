
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameObject collec;

    void OnTriggerEnter()
    {
        //Disactivate the collectible when the player touches it
        collec.SetActive(false);

        //Add them to the manager so it will be know at the end how many coins the player got
        FindObjectOfType<GameManager>().collected += 1;

    }
}
