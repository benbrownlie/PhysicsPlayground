using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveProjectileBehavior : MonoBehaviour
{
    public Rigidbody rigidbody;

    public IEnumerator DespawnTimer()
    {
        //Waits for the set amount of time before destroying the projectile
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    private void Update()
    {
        //Starts the timer
        StartCoroutine(DespawnTimer());
    }

    private IEnumerator OnCollisionEnter(Collision collision)
    {
        yield return new WaitForSeconds(3);
        rigidbody.AddExplosionForce(500, transform.position, 1000);
    }
}
