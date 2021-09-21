using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehavior : MonoBehaviour
{
    //The object that the spawner will instantiate
    public GameObject spawnable;
    //The target given to the spawned object
    public GameObject target;
    //Whether or not the spawner is allowed to spawn objects
    public bool canSpawn = false;
    //The maximum amount of objects the spawner can create
    public int maxSpawnCount;
    //The amount of seconds between items spawning
    public float timeBetweenSpawns;

    private void Start()
    {
        //Spawns objects
        StartCoroutine(SpawnObjects());
    }

    public IEnumerator SpawnObjects()
    {
        //Checks if spawing is desired
        if (canSpawn == true)
        {
            //Continues to spawn enemies while the iterator is less than the maximum number given
            for (int i = 0; i < maxSpawnCount; i++)
            {
                GameObject spawnedObject = Instantiate(spawnable, transform.position, new Quaternion());
                spawnedObject.GetComponent<EnemyBehavior>().target = target;

                //Gives each spawned object a number in their name, the number increases for each object spawned
                spawnedObject.name = spawnedObject.name + i;

                //Waits for the timer to finish before spawning again
                yield return new WaitForSeconds(timeBetweenSpawns);
            }
        }
    }

}
