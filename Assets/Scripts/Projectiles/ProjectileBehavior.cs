using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
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

    private void OnCollisionEnter(Collision collision)
    {
        //Checks if the collision is a breakable
        if (collision.gameObject.CompareTag("Breakable"))
        {
            //If so sets the Breakable to in-active and destroys itself
            collision.gameObject.SetActive(false);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
