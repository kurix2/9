using UnityEngine;
using System.Collections;

public class Simulate3D : MonoBehaviour {

    // Use this for initialization
    void Start() {
    }

      void OnTriggerEnter2D(Collider2D other)
    {
        GetComponent<SpriteRenderer>().sortingLayerName = "ForeGround";
    }

    void OnTriggerExit2D(Collider2D other)
    {
        GetComponent<SpriteRenderer>().sortingLayerName = "BackGround";
    }

}
