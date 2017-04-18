using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public GameObject redScreen;
    public bool isDead = false;

	// Use this for initialization
	void Start () {
 
    }

	// Update is called once per frame
	void Update () {
        if (isDead == true)
        {
            StartCoroutine(DeadTime());
        }
        
    }

	void OnCollisionEnter (Collision other){
		if (other.transform.tag == "Lava") {
            isDead = true;
        }
	}

    IEnumerator DeadTime() {
        SpriteRenderer n = redScreen.GetComponent<SpriteRenderer>();
        n.enabled = true;
        yield return new WaitForSeconds(3);
        Die();
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
