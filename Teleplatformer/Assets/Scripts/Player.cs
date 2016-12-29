using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.y < -15) {
			Die ();
		}
	}

	void OnTriggerEnter (Collider other){
		if (other.transform.tag == "Lava") {
			Die ();
		}
	}

	//void OnTriggerStay(Collider other){
	//	if (other.gameObject.tag == "Moving Platform") {
	//		transform.parent = other.transform;
	//		print ("Stay");
	//	}
	//}
	//void OnTriggerExit(Collider other){
	//	if (other.gameObject.tag == "Moving Platform") {
	//		transform.parent = null;
	//		print ("Exit");
	//	}
	//}

	void Die(){
		GameManager.RestartLevel ();
	}
}
