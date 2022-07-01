using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMaster : MonoBehaviour
{
    
    public GameObject Player;
    public float Distance;
    public float triggerDistance = 15f;

    public bool isAngered;

    public NavMeshAgent _agent;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Distance = Vector3.Distance(Player.transform.position, this.transform.position);


        if (Distance <=triggerDistance)
        {
            isAngered = true;
        }

        if (Distance > triggerDistance) 
        {
            isAngered = false;
        }

        if(isAngered)

        {
             _agent.isStopped = false;
            _agent.SetDestination(Player.transform.position);
        }
         else {
            _agent.isStopped = true;
        }


    }
}
