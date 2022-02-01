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
        if (Service.CollectableManagerInGame.collectableInstances.Count == 0) return;
        
        if (closestCollectable == null)
        {
            Service.AILifecycleManagerInGame.GetClosestCollectable(this.gameObject);
        }
        else
        { 
            Service.AILifecycleManagerInGame.InstanceUpdateDirection(this.gameObject, closestCollectable);
        }
    }
    
}
