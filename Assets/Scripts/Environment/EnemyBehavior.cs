using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    //Reference to the enemy's rigidbody
    public Rigidbody rigidbody;
    //Reference to the navmesh agent
    public NavMeshAgent agent;
    //Reference to the object the enemy will target
    public GameObject target;

    public GameObject[] patrolPoints;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        //Sets the enemy's destination to be the position of its target
        if (target)
        {
            agent.SetDestination(target.transform.position);
        }

        else
        {
            agent.SetDestination(patrolPoints[0].transform.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //If a Explosive projectile collides
        if (collision.gameObject.CompareTag("Explosive"))
        {

        }

        //If a Ice projectile collides
        if (collision.gameObject.CompareTag("Ice"))
        {
            rigidbody.isKinematic = false;
        }
    }
}
