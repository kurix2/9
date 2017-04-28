using UnityEngine;
using System.Collections;

public class TeleMovement : MonoBehaviour {

	private SteamVR_TrackedObject trackedObject;
	private SteamVR_Controller.Device device;
	public GameObject player;
	public GameObject telesphere;
	//public bool telesphereOn = false;
	private GameObject tossedSphere;

	void Start () {
		trackedObject = GetComponent<SteamVR_TrackedObject> ();
	}

	void Update () {
		device = SteamVR_Controller.Input((int)trackedObject.index);
		if(device.GetAxis().x != 0 || device.GetAxis().y != 0)
		{
			Debug.Log(device.GetAxis().x + " " + device.GetAxis().y);
		}
		if (device.GetHairTriggerDown())// (SteamVR_Controller.ButtonMask.Trigger)) //&& telesphereOn == true) 
        {
			GameObject tsphereInstance = Instantiate (telesphere, transform.position, Quaternion.identity) as GameObject;
            tsphereInstance.transform.parent = transform;
        }
        if (device.GetHairTriggerUp())
        {
            if (gameObject.transform.FindChild("TeleSphere(Clone)") != null)
            {
                gameObject.transform.FindChild("TeleSphere(Clone)").transform.parent = null;
            }
        }
    }
}