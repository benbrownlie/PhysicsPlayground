using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveProjectileBehavior : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rigidbody;

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

    private void OnCollisionEnter(Collision collision)
    {
        _rigidbody.AddExplosionForce(1000.0f, transform.position, 100.0f);
    }
}
