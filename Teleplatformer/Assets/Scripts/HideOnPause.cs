using UnityEngine;
using System.Collections;

public class HideOnPause : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    { 
        if (GameManager.Instance.Paused)
            {
                transform.GetComponent<Renderer>().enabled = false;
            }else
        {
            transform.GetComponent<Renderer>().enabled = true;
        }

}
}
