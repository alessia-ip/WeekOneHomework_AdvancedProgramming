using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int NumberOfAiInstances;
    public int NumberOfCollectables;

    public float gridSizeX;
    public float gridSizeZ;
    
    // Start is called before the first frame update
    void Start()
    {
        Service.GameManagerInGame = this;

        for (int i = 0; i != NumberOfAiInstances; i++)
        {
            Service.AILifecycleManagerInGame.InstanceCreation();
        }
        
        for (int i = 0; i != NumberOfCollectables; i++)
        {
            Service.CollectableManagerInGame.SpawnCollectable();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
