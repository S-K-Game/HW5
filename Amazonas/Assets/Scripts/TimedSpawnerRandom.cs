using System.Collections;
using UnityEngine;

/**
 * This component instantiates a given prefab at random time intervals and random bias from its object position.
 */
public class TimedSpawnerRandom : MonoBehaviour
{
    [SerializeField] Mover prefabToSpawn1;
    [SerializeField] Mover prefabToSpawn2;
    [SerializeField] Vector3 velocityOfSpawnedObject;
    [Tooltip("Minimum time between consecutive spawns, in seconds")] [SerializeField] float minTimeBetweenSpawns;
    [Tooltip("Maximum time between consecutive spawns, in seconds")] [SerializeField] float maxTimeBetweenSpawns;
    [Tooltip("Maximum distance in X between spawner and spawned objects, in meters")] [SerializeField] float maxXDistance;
    [Tooltip("Maximum distance in Y between spawner and spawned objects, in meters")] [SerializeField] float maxYDistance;
    private int zPos=-1;

    void Start()
    {
        this.StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            float timeBetweenSpawns = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            yield return new WaitForSeconds(timeBetweenSpawns);
            Vector3 positionOfSpawnedObject = new Vector3(
                transform.position.x + Random.Range(-maxXDistance, +maxXDistance),
                transform.position.y + Random.Range(-maxYDistance, +maxYDistance),
                zPos);

                if(timeBetweenSpawns < (minTimeBetweenSpawns + maxTimeBetweenSpawns)/2){
                    GameObject newObject = Instantiate(prefabToSpawn1.gameObject, positionOfSpawnedObject, Quaternion.identity);
                    newObject.GetComponent<Mover>().SetVelocity(velocityOfSpawnedObject);
                }
                else{
                    GameObject newObject = Instantiate(prefabToSpawn2.gameObject, positionOfSpawnedObject, Quaternion.identity);
                    newObject.GetComponent<Mover>().SetVelocity(velocityOfSpawnedObject);
                }
        }
    }

}