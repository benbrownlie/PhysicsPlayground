using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public IEnumerator DespawnTimer()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    private void Update()
    {
        StartCoroutine(DespawnTimer());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Breakable"))
        {
            collision.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
