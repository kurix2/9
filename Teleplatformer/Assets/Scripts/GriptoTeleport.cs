using UnityEngine;
using System.Collections;

public class GriptoTeleport : MonoBehaviour {
	private string initialText;
	private bool isTelesphere = false;
	//public GameObject telesphere;

	// Use this for initialization
	void Start () {
		initialText = gameObject.GetComponent<TextMesh> ().text;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindWithTag("TeleSphere")!=null){
			isTelesphere = true;
		}
		if (isTelesphere == true) {
			gameObject.GetComponent<TextMesh> ().text = initialText;
		} 
		else {
			gameObject.GetComponent<TextMesh> ().text = "Hold Trigger";
		}
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
