using UnityEngine;
using System.Collections;

public class FallThroughCollision : MonoBehaviour {
    
    private void OnCollisionEnter(Collision collision)
    {
        if (GetComponent<BoxCollider>().enabled)
         {
             GetComponent<BoxCollider>().enabled = false;
         }
    }
}
