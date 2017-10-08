using UnityEngine;
using System.Collections;

public class DisableBelowProgressX : MonoBehaviour {
    public int disableBelow;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.playerProgress<disableBelow)
        {
            gameObject.SetActive(false);
        }
    }
}