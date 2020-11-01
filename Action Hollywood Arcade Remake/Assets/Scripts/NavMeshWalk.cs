using AidensWork;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshWalk : MonoBehaviour
{
    NavMeshAgent agent;

    public Transform[] waypoints;
    Vector3 nextLocation;
    int currentWaypointCounter = 0;


    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        nextLocation = waypoints[0].position;
        agent.SetDestination(nextLocation);
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.Instance.GamePaused == true)
        {
            agent.isStopped = true;
        }
        
        if (PauseMenu.Instance.GamePaused == false)
        {
            agent.isStopped = false;
        }


        if (Vector3.Distance(nextLocation, this.transform.position) < .2)
        {
            currentWaypointCounter++;
            currentWaypointCounter %= waypoints.Length;
            nextLocation = waypoints[currentWaypointCounter].position;
            agent.SetDestination(nextLocation);
        }
    }
}
