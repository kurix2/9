using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TextInput : MonoBehaviour {
    public InputField inputField;
	
	void Awake () {
        inputField.onEndEdit.AddListener(AcceptStringInput);
	}

    void AcceptStringInput(string userInput)
    {

        if (PlayerController.Instance.inDanger)
        {
            BattleManager.Instance.AttemptHit(userInput);
        }else
        {
        userInput = userInput.ToLower();
        DialogSystem.Instance.DisplayDescription(userInput);
        }

        inputField.text = null;
        inputField.ActivateInputField();
        
    }
}
