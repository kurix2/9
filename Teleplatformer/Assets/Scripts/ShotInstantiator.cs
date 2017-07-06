using UnityEngine;
using System.Collections;

public class ShotInstantiator : MonoBehaviour {

    public GameObject shot;
    public float shotRate;

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnLoop());
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    IEnumerator SpawnLoop()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(shotRate);
            Instantiate(shot, transform.position, Quaternion.identity);
        }
    }
}
