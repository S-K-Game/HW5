using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component spawns the given object whenever the player clicks a given key.
 */
public class ArrowShooter: MonoBehaviour {
    [SerializeField] protected KeyCode keyForLeft;
    [SerializeField] protected KeyCode keyForRight;
    [SerializeField] protected GameObject prefabToSpawn;
    [SerializeField] protected Vector3 velocityOfSpawnedObject;


    protected virtual GameObject spawnObject(int dir) {
        // Step 1: spawn the new object.
        Vector3 positionOfSpawnedObject = transform.position;  // span at the containing object position.
        Quaternion rotationOfSpawnedObject = Quaternion.identity;  // no rotation.
        GameObject newObject = Instantiate(prefabToSpawn, positionOfSpawnedObject, rotationOfSpawnedObject);

        // Step 2: modify the velocity of the new object.
        Mover newObjectMover = newObject.GetComponent<Mover>();
        if (newObjectMover) {
            newObjectMover.SetVelocity(dir * velocityOfSpawnedObject);
        }

        Vector3 scale = newObject.transform.localScale;
        scale.x *= dir;
        newObject.transform.localScale = scale;

        return newObject;
    }

    void Update() { 
       if (Input.GetKeyDown(keyForLeft)) {
            spawnObject(-1);
        }
        else if(Input.GetKeyDown(keyForRight)){
            spawnObject(1);
        }
    }
}
