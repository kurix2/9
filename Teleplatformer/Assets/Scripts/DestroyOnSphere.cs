using UnityEngine;
using System.Collections;

public class DestroyOnSphere : MonoBehaviour {
    public GameObject explodeFX;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "TeleSphere")
        {
            Instantiate(explodeFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
