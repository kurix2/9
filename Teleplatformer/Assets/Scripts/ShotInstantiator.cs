using UnityEngine;
using System.Collections;

public class ShotInstantiator : MonoBehaviour {

    public GameObject shot;
    public Transform glassReceiver;
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
            Quaternion spawnRotation = glassReceiver.rotation;
            GameObject shotInstance = Instantiate(shot, transform.position, spawnRotation)as GameObject;
            shotInstance.GetComponent<MoveToTerminate>().terminationPoint = glassReceiver;
        }
    }
}
