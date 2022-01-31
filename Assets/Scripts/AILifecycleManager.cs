using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using Random = UnityEngine.Random;

public class AILifecycleManager : MonoBehaviour
{
    
    public GameObject AiPrefab;
    public float aiMoveSpeed;
    public float aiRotationSpeed;
    
    //this is a list of all the AI objects in the scene
    public List<GameObject> aiInstances = new List<GameObject>();
    
    void Awake()
    {
        Service.AILifecycleManagerInGame = this;
    }

    public void FixedUpdate()
    {
        InstanceUpdatePosition();
    }

    //this creates each instance of the AI
    public void InstanceCreation()
    {
        var newInstance = Instantiate<GameObject>(AiPrefab);
        var newPosition = new Vector3(
            Random.Range(-Service.GameManagerInGame.gridSizeX, Service.GameManagerInGame.gridSizeX),
            newInstance.transform.position.y,
            Random.Range(-Service.GameManagerInGame.gridSizeZ, Service.GameManagerInGame.gridSizeZ)
            );
        newInstance.transform.position = newPosition;
        newInstance.AddComponent<AIClosestCollectable>();
        aiInstances.Add(newInstance);
    }

    public void GetClosestCollectable(GameObject aiInstance)
    {
        //This is to avoid trying to sort a list here

        var tempCollectableHolder = Service.CollectableManagerInGame.collectableInstances[0];

        for (int i = 1; i < Service.CollectableManagerInGame.collectableInstances.Count; i++)
        {
            var currentDistance = Vector3.Distance(aiInstance.transform.position, tempCollectableHolder.transform.position);
            var compDistance = Vector3.Distance(aiInstance.transform.position, Service.CollectableManagerInGame.collectableInstances[i].transform.position);
            if (currentDistance > compDistance)
            {
                tempCollectableHolder = Service.CollectableManagerInGame.collectableInstances[i];
            }
        }

        aiInstance.GetComponent<AIClosestCollectable>().closestCollectable = tempCollectableHolder;
    }
    
    public void InstanceUpdateDirection(GameObject aiInstance)
    {
        
    }
    
    public void InstanceUpdatePosition()
    {
        for (int i=0; i < aiInstances.Count; i++)
        {
            var aiRigidbody = aiInstances[i].GetComponent<Rigidbody>();
            aiRigidbody.AddForce(aiRigidbody.transform.forward * aiMoveSpeed);
        }
    }
    
    public void Destruction()
    {
        
    }

    public void InstanceTracking()
    {
        
    }
   
}
