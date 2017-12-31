using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour {
    public static DialogSystem Instance { get; set; }

    public string description="default";

    private GameObject inspectFrame;
    private Text textField;


	// Use this for initialization
	void Awake () {
        inspectFrame = transform.Find("Frame").gameObject;
        textField = inspectFrame.transform.Find("DescriptionField").GetComponent<Text>();

        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }else { Instance = this; }
	}

    public void DisplayDescription(string areaText)
    {
        inspectFrame.SetActive(true);
        description = areaText;
        textField.text = description;
    }

    public void HideDescription()
    {
        inspectFrame.SetActive(false);
    }

    public void BattleDialog(string enemy, int hitRange)
    {
        description = "You Encounter a " + enemy + "\nPick a number between 1 and " + hitRange + " to fight";
        textField.text = description;
    }

    public void ChangeDialog(string newDialog)
    {
        description = newDialog;
        textField.text = description;
    }
}
