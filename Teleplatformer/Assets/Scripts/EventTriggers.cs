using UnityEngine;
using System.Collections;

public class EventTriggers : MonoBehaviour {
	//public GameObject player;
	public GameObject head;

	private bool isLava =false;
	private GameObject lava;

	// Use this for initialization
	void Start () {
		if (GameObject.FindWithTag ("Lava") != null) {
			lava = GameObject.FindWithTag ("Lava");
			isLava = true;
		}
	}

	// Update is called once per frame
	void Update () {
		if(head!=null && isLava==true){
			//if(player.transform.position.x >= 10)
			//{
			//lava.transform.Translate (Vector3.back * Time.deltaTime*riseSpeed);
		//}
			if (head.transform.position.y < lava.transform.position.y) {
			Die ();
			}
		}
		if (head == null) {
			head = GameObject.FindWithTag ("Player");
			if (head.transform.position.y < -30) {
				Die ();
			}
		}
	}

	void Die(){
		GameManager.RestartLevel ();
	}
}
