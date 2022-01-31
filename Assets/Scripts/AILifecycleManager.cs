using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AILifecycleManager : MonoBehaviour
{
    
    public GameObject AiPrefab;
    
    //this is a list of all the AI objects in the scene
    public List<GameObject> aiInstances = new List<GameObject>();
    
    void Awake()
    {
        Service.AILifecycleManagerInGame = this;
    }

    //this creates each instance of the AI
    public void InstanceCreation()
    {
        var newInstance = Instantiate<GameObject>(AiPrefab);
        
        aiInstances.Add(newInstance);
    }

    
    public void InstanceUpdating()
    {
        
    }

    public void Destruction()
    {
        
    }

    public void InstanceTracking()
    {
        
    }
   
}
