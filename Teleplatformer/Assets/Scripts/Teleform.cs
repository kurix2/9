using UnityEngine;
using System.Collections;

public class Teleform : MonoBehaviour {
	public GameObject explodeFX;

	//void OnCollisionEnter(Collision other){
	void OnTriggerEnter(Collider other){
		if (other.transform.tag == "Minotaur") {
			warn ();
		}
	}
		
	public void warn(){
		GetComponent<Animation> ().Play ();
		StartCoroutine (Delay ());
		//Instantiate (explodeFX, transform.position, Quaternion.identity);
		//Destroy (gameObject,1f);
	}

	IEnumerator Delay(){
		yield return new WaitForSeconds (1);
		Instantiate (explodeFX, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}