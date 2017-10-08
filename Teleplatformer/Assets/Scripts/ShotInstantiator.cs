using UnityEngine;
using System.Collections;

public class ShotInstantiator : MonoBehaviour
{

    public GameObject[] shot;
    public Transform glassReceiver;
    public float shotRate;
    public bool randomRotation = false;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnLoop()
    {
        if (GameManager.Instance.Paused != true)
        {
            while (enabled)
            {
                yield return new WaitForSeconds(shotRate);
                Quaternion spawnRotation = glassReceiver.rotation;
                GameObject shotInstance = Instantiate(shot[Random.Range(0, shot.Length)], transform.position, spawnRotation) as GameObject;
                shotInstance.GetComponent<MoveToTerminate>().terminationPoint = glassReceiver;
                if (randomRotation == true)
                {
                    int horFlip = Random.Range(0, 2);
                    int verFlip = Random.Range(0, 2);
                    shotInstance.transform.Rotate(new Vector3(horFlip * 180, verFlip * 180));
                    print("hor is" + horFlip);
                    print("ver is" + verFlip);
                }
            }
        }
    }
}
