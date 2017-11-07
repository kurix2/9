using UnityEngine;
using System.Collections;

public class HideOnPause : MonoBehaviour {
    public bool showOnPause = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (showOnPause)
        {
            if (GameManager.Instance.Paused)
            {
                transform.GetComponent<Renderer>().enabled = true;
            }
            else
            {
                transform.GetComponent<Renderer>().enabled = false;
            }
        }
        else
        {
            if (GameManager.Instance.Paused)
            {
                transform.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                transform.GetComponent<Renderer>().enabled = true;
            }
        }

}
}
