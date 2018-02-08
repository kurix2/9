using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject inventoryFrame;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryFrame.activeSelf)
            {
                inventoryFrame.SetActive(false);
            }
            else
            {
                inventoryFrame.SetActive(true);
            }
        }
		
	}
}
