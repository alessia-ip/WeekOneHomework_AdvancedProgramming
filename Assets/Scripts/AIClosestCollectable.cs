using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIClosestCollectable : MonoBehaviour
{
    public GameObject closestCollectable;

    private void Update()
    {
        GetTheClosestCollectable();
    }

    public void GetTheClosestCollectable()
    {
        //if there's NO collectables in the scene, we escape this function to avoid an error
        if (Service.CollectableManagerInGame.collectableInstances.Count == 0) return;
        
        //If the closest collectable is null (destroyed) then we want to grab a new one
        if (closestCollectable == null)
        {
            Service.AILifecycleManagerInGame.GetClosestCollectable(this.gameObject);
        }
        else //otherwise, we want to update our direction to face the collectable in question
        { 
            Service.AILifecycleManagerInGame.InstanceUpdateDirection(this.gameObject, closestCollectable);
        }
    }
    
}
