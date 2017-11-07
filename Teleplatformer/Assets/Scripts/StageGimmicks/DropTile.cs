using UnityEngine;
using System.Collections;

public class DropTile : MonoBehaviour {
	public Transform dropPoint;
	public float dropSpeed = 1;
	public bool startDrop = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (startDrop == true) {
			transform.position = Vector3.MoveTowards (transform.position, dropPoint.position, dropSpeed * Time.deltaTime);
		}
	}

	void OnCollisionEnter(Collision other){
		if (other.transform.tag == "Player") 
		{
			startDrop = true;
			GetComponent<Animation> ().Play ();
			Destroy (gameObject, 5);
		}
	}
}