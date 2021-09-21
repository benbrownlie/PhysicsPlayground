using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehavior : MonoBehaviour
{
    public GameObject spawnable;
    public GameObject target;
    public bool canSpawn = false;
    public int maxSpawnCount;
    public float timeBetweenSpawns;

    private void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    public IEnumerator SpawnObjects()
    {
        for (int i = 0; i < maxSpawnCount; i++)
        {
            GameObject spawnedObject = Instantiate(spawnable, transform.position, new Quaternion());

            spawnedObject.GetComponent<EnemyBehavior>().target = target;
            spawnedObject.name = spawnedObject.name + i;

            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

}
