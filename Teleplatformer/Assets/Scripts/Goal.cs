﻿using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {
	public float moveSpeed = 0.5f;
	public Transform loadTrigger;

	private bool finish = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (finish == true) {
			transform.position = Vector3.MoveTowards (transform.position, loadTrigger.position, Time.deltaTime * moveSpeed);
		}
		if(transform.position.y >= loadTrigger.position.y-1)
		{
			GameManager.CompleteLevel ();
			}
		}

	void OnCollisionEnter (Collision other){
		if (other.transform.tag == "Player") {
			finish = true;
		}
	}
}