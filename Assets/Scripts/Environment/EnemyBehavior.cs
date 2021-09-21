using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public Rigidbody rigidbody;
    public NavMeshAgent agent;
    public GameObject target;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        agent.SetDestination(target.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Explosive"))
        {

        }

        if (collision.gameObject.CompareTag("Ice"))
        {
            rigidbody.isKinematic = false;
        }
    }
}
