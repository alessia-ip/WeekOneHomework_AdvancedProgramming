using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCollectable : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Collectable")
        {
            Service.CollectableManagerInGame.destroyCollectable(other.gameObject);
        }
    }
}
