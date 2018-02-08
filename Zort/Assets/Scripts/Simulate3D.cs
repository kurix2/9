using UnityEngine;
using System.Collections;

public class Simulate3D : MonoBehaviour {
    private GameObject player;
    private int playersOrder;
    private int assignedOrder;

    // Use this for initialization
    void Start() {
       player = GameObject.Find("Player");
       playersOrder = player.GetComponent<SpriteRenderer>().sortingOrder;
    }

      void OnTriggerEnter2D(Collider2D other)
    {
        assignedOrder = GetComponent<SpriteRenderer>().sortingOrder;
        GetComponent<SpriteRenderer>().sortingOrder += playersOrder;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        GetComponent<SpriteRenderer>().sortingOrder = assignedOrder;
    }

}
