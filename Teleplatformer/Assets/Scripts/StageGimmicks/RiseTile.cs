using UnityEngine;
using System.Collections;

public class RiseTile : MonoBehaviour {
    public float speed = 2.0f;
    public Transform patrolPoint;
    private bool rise = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (rise)
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoint.position, speed * Time.deltaTime);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rise = true;
        }
    }
}
