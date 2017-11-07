using UnityEngine;
using System.Collections;

public class ShowOnStart : MonoBehaviour {
    public bool HideOnPause = true;

	// Use this for initialization
	void Start () {
        //transform.GetComponent<Renderer>().enabled = true;
    }

    // Update is called once per frame
    void Update () {
        /*if (GameManager.Instance.Paused)
        {
            transform.GetComponent<Renderer>().enabled = false;
        }else { transform.GetComponent<Renderer>().enabled = true; }
	*/
        if (HideOnPause)
        {
            if (GameManager.Instance.Paused)
            {
                gameObject.SetActive(false);
            }
            else { gameObject.SetActive(true); }
        }
        else
        {
            if (GameManager.Instance.Paused)
            {
                gameObject.SetActive(true);
            }
            else { gameObject.SetActive(false); }
        }
    }
}
