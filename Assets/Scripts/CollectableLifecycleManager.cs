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
        //we self assign to the services manager
        Service.CollectableManagerInGame = this;
    }

    //we spawn collectables with this
    public void SpawnCollectable()
    {
        //we instantiate a new collectable prefab
        var newCollectable = Instantiate<GameObject>(collectablePrefab);
        //we generate a new random position in the play space
        var newPosition = new Vector3(
            Random.Range(-Service.GameManagerInGame.gridSizeX, Service.GameManagerInGame.gridSizeX),
            newCollectable.transform.position.y,
            Random.Range(-Service.GameManagerInGame.gridSizeZ, Service.GameManagerInGame.gridSizeZ)
        );
        //we put the collectable at that position
        newCollectable.transform.position = newPosition;
        //and then we add our collectable to the list
        collectableInstances.Add(newCollectable);
    }

    //We destroy collectables that have been touched by this
    public void destroyCollectable(GameObject collectable)
    {
        //we have to fix the list for when the collectable is destroyed
        //so we use a for loop to cycle through it
        for (int i = 0; i < collectableInstances.Count; i++)
        {
            //when we find the right one in the list, we do the things in this if statement
            if (collectableInstances[i] == collectable)
            {
                collectableInstances.RemoveAt(i); //we remove it from the list, so there isn't a null/missing in our list
                Destroy(collectable); // then we destroy the gameobject
                return; //and then we escape this since we found what we needed and don't need to cycle through the rest of the list
            }
        }
        
        
    }
    
}
