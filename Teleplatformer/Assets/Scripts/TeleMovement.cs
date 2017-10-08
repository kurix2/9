using UnityEngine;
using System.Collections;

public class TeleMovement : MonoBehaviour {

	private SteamVR_TrackedObject trackedObject;
	private SteamVR_Controller.Device device;
	public GameObject player;
	public GameObject telesphere;
    private Transform pauseTeleport;
    private Vector3 returnTeleport;
    [Space]
    public GameObject placeMarker;
    public float markDisplaceY = 5f;

	void Start () {
		trackedObject = GetComponent<SteamVR_TrackedObject> ();
        returnTeleport = player.transform.position;
        if (GameObject.Find("Pause Teleport") != null)
        {
            pauseTeleport = GameObject.Find("Pause Teleport").transform;
        }
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
        if (device.GetPressDown(Valve.VR.EVRButtonId.k_EButton_ApplicationMenu) && pauseTeleport != null)
        {
            if (GameManager.Instance.Paused != true)
            {
                returnTeleport = player.transform.position;
                Vector3 markPos = new Vector3(transform.position.x, transform.position.y + markDisplaceY, transform.position.z);
                Instantiate(placeMarker, player.transform.position, Quaternion.identity);
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