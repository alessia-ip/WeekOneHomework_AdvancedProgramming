using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int NumberOfAiInstances;
    public int NumberOfCollectables;
    
    // Start is called before the first frame update
    void Start()
    {
        Service.GameManagerInGame = this;

        for (int i = 0; i != NumberOfAiInstances - 1; i++)
        {
            Service.AILifecycleManagerInGame.InstanceCreation();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
