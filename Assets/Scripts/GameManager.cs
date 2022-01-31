using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int NumberOfAiInstances;
    public int NumberOfCollectables;

    public float gridSizeX;
    public float gridSizeZ;
    
    public GameObject AiPrefab;
    public float aiMoveSpeed;
    public float aiRotationSpeed;

    private void Awake()
    {
        Service.InitializationService();
    }

    // Start is called before the first frame update
    void Start()
    {
        Service.GameManagerInGame = this;

        for (int i = 0; i != NumberOfAiInstances; i++)
        {
            var newInstance = Instantiate<GameObject>(AiPrefab);
            Service.AILifecycleManagerInGame.InstanceCreation(newInstance);
        }
        
        for (int i = 0; i != NumberOfCollectables; i++)
        {
            Service.CollectableManagerInGame.SpawnCollectable();
        }
    }
    
    public void FixedUpdate()
    {
        Service.AILifecycleManagerInGame.InstanceUpdatePosition(aiMoveSpeed);
    }

    
}
