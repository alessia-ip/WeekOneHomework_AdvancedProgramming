using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using Random = UnityEngine.Random;

public class CollectableLifecycleManager : MonoBehaviour
{

    public GameObject collectablePrefab;
    
    //this is a list of all of our spawned collectables
    public List<GameObject> collectableInstances = new List<GameObject>();
    
    void Awake()
    {
        Service.CollectableManagerInGame = this;
    }

    public void SpawnCollectable()
    {
        var newCollectable = Instantiate<GameObject>(collectablePrefab);
        var newPosition = new Vector3(
            Random.Range(-Service.GameManagerInGame.gridSizeX, Service.GameManagerInGame.gridSizeX),
            newCollectable.transform.position.y,
            Random.Range(-Service.GameManagerInGame.gridSizeZ, Service.GameManagerInGame.gridSizeZ)
        );
        newCollectable.transform.position = newPosition;
        collectableInstances.Add(newCollectable);
    }

    public void destroyCollectable(GameObject collectable)
    {
        //we have to fix the list for when the collectable is destroyed
        for (int i = 0; i < collectableInstances.Count; i++)
        {
            if (collectableInstances[i] == collectable)
            {
                collectableInstances.RemoveAt(i);
                Destroy(collectable);
                return;
            }
        }
        
        
    }
    
}
