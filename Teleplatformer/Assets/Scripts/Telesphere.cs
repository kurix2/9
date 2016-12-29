using UnityEngine;
using System.Collections;

public class Telesphere : MonoBehaviour {
	private GameObject player;
	public GameObject teleportFX_01;
	public GameObject teleportFX_02;
	public float teleportDelay = 0.1f;
	public Renderer rend;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		rend = GetComponent<Renderer> ();
		rend.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -20) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter (Collision other)
	{
		if (other.transform.tag == "Teleform" || other.transform.tag == "Finish") {
			StartCoroutine (Teleport());
			//player.transform.position = gameObject.transform.position;
			//Destroy (gameObject);
		}
		if (other.transform.tag == "Lava") {
			Destroy (gameObject);
		}
	}

	IEnumerator Teleport(){
		while (true) {
			rend.enabled = false;
			Instantiate (teleportFX_01, transform.position, Quaternion.Euler(new Vector3(-90,0,0)));
			yield return new WaitForSeconds (teleportDelay);
			player.transform.position = gameObject.transform.position;
			Instantiate (teleportFX_02, transform.position, Quaternion.Euler(new Vector3(-90,0,0)));
			Destroy (gameObject);
		}
	}
}