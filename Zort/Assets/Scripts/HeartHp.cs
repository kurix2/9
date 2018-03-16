using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartHp : MonoBehaviour {
    public Transform[] hearts;

	// Use this for initialization
	void Start () {
        CalculateHp();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CalculateHp()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (BattleManager.Instance.playerMxHp < (i+1)*4)
            {
                hearts[i].gameObject.SetActive(false);
            }
            else { hearts[i].gameObject.SetActive(true); }
        }

        bool fin = false;

        for (int i = 0; i < hearts.Length; i++)
        {
            Image fill =
                hearts[i].transform.GetChild(0).GetComponent<Image>();

            if (fin)
            {
                fill.fillAmount = 0;
            }
            else
            {


            if (BattleManager.Instance.playerHp >= (i+1)*4)
            {
                fill.fillAmount = 1;
            }
            else
            {
                fill.fillAmount = (BattleManager.Instance.playerHp % 4)*0.25f;
                fin = true;
            }

            }
        }
    }
}
