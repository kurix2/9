using UnityEngine;
using System.Collections;

public class TeleMovement : MonoBehaviour {

	private SteamVR_TrackedObject trackedObject;
	private SteamVR_Controller.Device device;
	public GameObject player;
	public GameObject telesphere;
    private Transform pauseTeleport;
    private Vector3 returnTeleport;

	void Start () {
		trackedObject = GetComponent<SteamVR_TrackedObject> ();
        returnTeleport = player.transform.position;
        pauseTeleport = GameObject.Find("Pause Teleport").transform;
	}

    void Update()
    {
        device = SteamVR_Controller.Input((int)trackedObject.index);
        if (device.GetHairTriggerDown())
        {
            GameObject tsphereInstance = Instantiate(telesphere, transform.position, Quaternion.identity) as GameObject;
            tsphereInstance.transform.parent = transform;
        }
        if (device.GetHairTriggerUp())
        {
            if (gameObject.transform.FindChild("TeleSphere(Clone)") != null)
            {
                gameObject.transform.FindChild("TeleSphere(Clone)").transform.parent = null;
            }
        }
        if (device.GetPressDown(Valve.VR.EVRButtonId.k_EButton_ApplicationMenu))
        {
            if (GameManager.Instance.Paused != true)
            {
                returnTeleport = player.transform.position;
                GameManager.Instance.PauseGame();
                player.transform.position = pauseTeleport.position;
            }
            else
            {
                player.transform.position = returnTeleport;
                GameManager.Instance.PauseGame();
            }
        }
    }
}