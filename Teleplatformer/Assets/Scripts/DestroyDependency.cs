using UnityEngine;
using System.Collections;

public class DestroyDependency : MonoBehaviour {
    public GameObject dependant;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (dependant == null)
        {
            Destroy(gameObject);
        }
	
	}
}
