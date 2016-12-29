using UnityEngine;
using System.Collections;

public class LavaTrigger : MonoBehaviour {
	public GameObject lava;
	public float riseSpeed = 0.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other){
		if (other.transform.tag == "Player") {
			lava.transform.Translate (Vector3.back * Time.deltaTime*riseSpeed);
		}
	}
}
