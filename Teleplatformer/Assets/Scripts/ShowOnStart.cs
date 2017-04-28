using UnityEngine;
using System.Collections;

public class ShowOnStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // SpriteRenderer n = redScreen.GetComponent<SpriteRenderer>();
        //n.enabled = true;
        transform.GetComponent<Renderer>().enabled = true;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
