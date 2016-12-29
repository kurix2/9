using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {
	public float Lifetime=2f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (gameObject, Lifetime);
	}
}
