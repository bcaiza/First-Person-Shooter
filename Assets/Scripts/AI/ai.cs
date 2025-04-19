using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ai : MonoBehaviour
{

    public NavMeshAgent navMeshAgent;


    public float distanceToFollowPath = 2;

    public Transform[] destinations;

    private int i = 0;

    public bool followPlayer;

    private GameObject player;

    private float disnatceToPlayer;

    public float distanceToFollowPlayer = 10;


    void Start()
    {
        navMeshAgent.destination = destinations[0].transform.position;
        player = FindObjectOfType<PlayermOvement>().gameObject;
    }


    void Update()
    {
        disnatceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (disnatceToPlayer <= distanceToFollowPlayer && followPlayer)
        {
            FollowPlayer();
        }
        else
        {
            EnemyPath();
        }
    }

    public void EnemyPath()
    {
        
        navMeshAgent.destination = destinations[i].position;

        if (Vector3.Distance(transform.position, destinations[i].position) <=  distanceToFollowPath)
        {
            if (destinations[i] != destinations[destinations.Length -1])
            {
                i++;
            }
            else
            {
                i = 0;
            }
        }
    }

    public void FollowPlayer()
    {
        navMeshAgent.destination = player.transform.position;
    }
}




