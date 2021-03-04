using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class npcController : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;

    public float maxDistance = 8;

    private Vector3 start;
    private float baseSpeed;


    void Start()
    {
        start = this.transform.position;
        baseSpeed = agent.speed;
    }

    // Update is called once per frame
    void Update()
    {
        //reduce its speed while on off mesh link as it's pretty fast
        if (agent.isOnOffMeshLink)
        {
            agent.speed = baseSpeed / 4;
        } else
        {
            agent.speed = baseSpeed;
        }


        float dist = Vector3.Distance(player.transform.position, agent.transform.position);
   
        //agent will chase the player only if close enough
        if (dist < maxDistance)
        {
            agent.SetDestination(player.transform.position);
        } else
        {
            agent.SetDestination(start);
        }
        

        
    }
}
