using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public float playerMoveSpeed;
    public float playerRotationSpeed;
    public GameObject player;
    public Rigidbody playerRigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        Service.playerManagerInGame = this;
        playerRigidbody = player.GetComponent<Rigidbody>();
        player.AddComponent<DestroyCollectable>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayerForward();
        TurnPlayer();
        
    }

    public void MovePlayerForward()
    {
        if (!Input.GetKey(KeyCode.UpArrow)) return;
        
        playerRigidbody.AddForce(player.transform.forward * playerMoveSpeed);
    }

    public void TurnPlayer()
    {
        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)) return;

        int isLeft;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            isLeft = -1;
            
        }
        else
        {
            isLeft = 1;
        }
        
        playerRigidbody.transform.Rotate(new Vector3(0, 5 * isLeft * playerRotationSpeed, 0) * Time.deltaTime);
    }

   
    
}
