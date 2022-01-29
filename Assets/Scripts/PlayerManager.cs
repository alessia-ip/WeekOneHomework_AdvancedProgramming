using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Service.playerManagerInGame = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
